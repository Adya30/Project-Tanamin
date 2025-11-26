using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_pesanan
    {
        private readonly connectdata db;

        public c_pesanan()
        {
            db = new connectdata();
        }

        public List<(m_transaksi transaksi, m_detailtransaksi detail, m_produk produk)>
            GetPesananByUser(int userId, string status)
        {
            var list = new List<(m_transaksi, m_detailtransaksi, m_produk)>();

            using (var conn = db.getConn())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        t.id_transaksi, t.tanggal_transaksi, t.status_transaksi, 
                        t.pembayaran, t.detail_alamat,

                        d.id_detailtransaksi, d.jumlah, d.harga_satuan, d.id_produk,

                        p.id_produk, p.nama_produk, p.nama_kategori, p.deskripsi

                    FROM transaksi t
                    INNER JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                    INNER JOIN produk p ON d.id_produk = p.id_produk
                    WHERE t.id_user = @uid AND t.status_transaksi = @status
                    ORDER BY t.tanggal_transaksi DESC;
                ";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@uid", userId);
                    cmd.Parameters.AddWithValue("@status", status);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var transaksi = new m_transaksi
                            {
                                id_transaksi = reader.GetInt32(0),
                                tanggal_transaksi = reader.GetDateTime(1),
                                status_transaksi = reader.GetString(2),
                                pembayaran = reader.GetString(3),
                                detail_alamat = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                id_user = userId
                            };

                            var detail = new m_detailtransaksi
                            {
                                id_detailtransaksi = reader.GetInt32(5),
                                jumlah_transaksi = reader.GetInt32(6),   // <== jumlah dari DB
                                harga_satuan = reader.GetInt32(7),
                                id_transaksi = transaksi.id_transaksi,
                                id_produk = reader.GetInt32(8)
                            };

                            var produk = new m_produk
                            {
                                IdProduk = reader.GetInt32(9),
                                NamaProduk = reader.GetString(10),
                                NamaKategori = reader.GetString(11),
                                Deskripsi = reader.IsDBNull(12) ? "" : reader.GetString(12)
                            };

                            list.Add((transaksi, detail, produk));
                        }
                    }
                }
            }

            return list;
        }
    }
}
