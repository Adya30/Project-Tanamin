using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_Pembayaran
    {
        private readonly connectdata db;

        public c_Pembayaran()
        {
            db = new connectdata();
        }

        /// <summary>
        /// Proses pembayaran: otomatis pakai CurrentUser.IdUser
        /// </summary>
        /// <param name="keranjang">List produk + jumlah</param>
        /// <param name="bank">Nama bank</param>
        /// <param name="alamatLengkap">Alamat pengiriman</param>
        /// <param name="statusTransaksi">Status awal (misal "Diantar")</param>
        /// <returns>True jika sukses</returns>
        public bool ProsesPembayaran(List<(m_produk produk, int jumlah)> keranjang, string bank, string alamatLengkap, string statusTransaksi = "Diantar")
        {
            if (c_user.CurrentUser == null)
                throw new Exception("User belum login");

            var transaksi = new m_transaksi
            {
                tanggal_transaksi = DateTime.Now,
                status_transaksi = statusTransaksi,
                pembayaran = bank,
                detail_alamat = alamatLengkap,
                id_user = c_user.CurrentUser.IdUser,
                id_desa = null // jika ingin diisi, bisa ambil dari UI
            };

            var listDetail = new List<m_detailtransaksi>();
            foreach (var item in keranjang)
            {
                listDetail.Add(new m_detailtransaksi
                {
                    id_produk = item.produk.IdProduk,
                    jumlah_transaksi = item.jumlah,
                    harga_satuan = item.produk.HargaSatuan
                });
            }

            return SimpanTransaksi(transaksi, listDetail);
        }

        /// <summary>
        /// Simpan transaksi + detail transaksi ke database
        /// </summary>
        private bool SimpanTransaksi(m_transaksi transaksi, List<m_detailtransaksi> listDetail)
        {
            try
            {
                using (var conn = new NpgsqlConnection(db.connstring))
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Insert transaksi utama
                            string queryTransaksi = @"
                                INSERT INTO transaksi 
                                (tanggal_transaksi, status_transaksi, pembayaran, detail_alamat, id_user, id_desa) 
                                VALUES (@tgl, @status, @bayar, @alamat, @id_user, @id_desa) 
                                RETURNING id_transaksi";

                            int idTransaksi;
                            using (var cmd = new NpgsqlCommand(queryTransaksi, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@tgl", transaksi.tanggal_transaksi);
                                cmd.Parameters.AddWithValue("@status", transaksi.status_transaksi ?? "");
                                cmd.Parameters.AddWithValue("@bayar", transaksi.pembayaran ?? "");
                                cmd.Parameters.AddWithValue("@alamat", transaksi.detail_alamat ?? "");
                                cmd.Parameters.AddWithValue("@id_user", transaksi.id_user ?? (object)DBNull.Value);
                                cmd.Parameters.AddWithValue("@id_desa", transaksi.id_desa ?? (object)DBNull.Value);

                                idTransaksi = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            // 2. Insert detail transaksi & kurangi stok
                            foreach (var item in listDetail)
                            {
                                string queryDetail = @"
                                    INSERT INTO detail_transaksi
                                    (harga_satuan, jumlah, id_transaksi, id_produk)
                                    VALUES (@harga, @jumlah, @id_transaksi, @id_produk)";

                                using (var cmd = new NpgsqlCommand(queryDetail, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@harga", item.harga_satuan);
                                    cmd.Parameters.AddWithValue("@jumlah", item.jumlah_transaksi);
                                    cmd.Parameters.AddWithValue("@id_transaksi", idTransaksi);
                                    cmd.Parameters.AddWithValue("@id_produk", item.id_produk ?? (object)DBNull.Value);
                                    cmd.ExecuteNonQuery();
                                }

                                // Kurangi stok
                                string queryKurangiStok = @"
                                    UPDATE produk
                                    SET stok_produk = stok_produk - @jumlah
                                    WHERE id_produk = @id AND stok_produk >= @jumlah";

                                using (var cmd = new NpgsqlCommand(queryKurangiStok, conn, tran))
                                {
                                    cmd.Parameters.AddWithValue("@jumlah", item.jumlah_transaksi);
                                    cmd.Parameters.AddWithValue("@id", item.id_produk ?? (object)DBNull.Value);
                                    int rows = cmd.ExecuteNonQuery();
                                    if (rows == 0)
                                        throw new Exception($"Stok produk ID {item.id_produk} tidak cukup");
                                }
                            }

                            tran.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            Console.WriteLine("Gagal simpan transaksi: " + ex.Message);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error SimpanTransaksi: " + ex.Message);
                return false;
            }
        }

        public bool ProsesPembayaran(int idUser, List<(m_produk produk, int jumlah)> keranjang, string bank, string alamat, string status)
        {
            // konversi keranjang ke List<m_detailtransaksi>
            List<m_detailtransaksi> listDetail = new List<m_detailtransaksi>();
            foreach (var item in keranjang)
            {
                listDetail.Add(new m_detailtransaksi
                {
                    id_produk = item.produk.IdProduk,
                    jumlah_transaksi = item.jumlah,
                    harga_satuan = item.produk.HargaSatuan
                });
            }

            m_transaksi transaksi = new m_transaksi
            {
                tanggal_transaksi = DateTime.Now,
                status_transaksi = status,
                pembayaran = bank,
                detail_alamat = alamat,
                id_user = idUser,
                id_desa = null // kalau belum ada, bisa dikosongkan
            };

            return SimpanTransaksi(transaksi, listDetail);
        }

    }
}
