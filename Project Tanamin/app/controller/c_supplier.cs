using Npgsql;
using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_supplier
    {
        private readonly connectdata db;

        public c_supplier()
        {
            db = new connectdata();
        }

        public int InsertPembelian(
            DateTime tanggal,
            string namaSupplier,
            decimal nominalPembelian,
            List<(m_produk produk, int jumlah)> keranjang)
        {
            if (nominalPembelian > int.MaxValue)
            {
                return -1;
            }

            using var conn = new NpgsqlConnection(db.connstring);
            conn.Open();
            using var tran = conn.BeginTransaction();

            int idPembelian = 0;

            string insertPembelian = @"
                INSERT INTO pembelian (tanggal_pembelian, nama_supplier, pembayaran_supplier)
                VALUES (@tanggal, @nama, @nominal)
                RETURNING id_pembelian;";

            using (var cmd = new NpgsqlCommand(insertPembelian, conn, tran))
            {
                cmd.Parameters.AddWithValue("@tanggal", tanggal);
                cmd.Parameters.AddWithValue("@nama", namaSupplier);

                cmd.Parameters.AddWithValue("@nominal", Convert.ToInt32(nominalPembelian));

                idPembelian = Convert.ToInt32(cmd.ExecuteScalar());
            }

            foreach (var item in keranjang)
            {
                string insertDetail = @"
                    INSERT INTO detail_pembelian
                        (jumlah_pembelian, id_produk, id_pembelian)
                    VALUES
                        (@jumlah, @id_produk, @id_pembelian);";

                using var cmdDetail = new NpgsqlCommand(insertDetail, conn, tran);
                cmdDetail.Parameters.AddWithValue("@jumlah", item.jumlah);
                cmdDetail.Parameters.AddWithValue("@id_produk", item.produk.IdProduk);
                cmdDetail.Parameters.AddWithValue("@id_pembelian", idPembelian);
                cmdDetail.ExecuteNonQuery();


                string updateStok = @"
                    UPDATE produk
                    SET stok_produk = stok_produk + @jumlah
                    WHERE id_produk = @id_produk;";

                using var cmdStok = new NpgsqlCommand(updateStok, conn, tran);
                cmdStok.Parameters.AddWithValue("@jumlah", item.jumlah);
                cmdStok.Parameters.AddWithValue("@id_produk", item.produk.IdProduk);
                cmdStok.ExecuteNonQuery();
            }

            tran.Commit();
            return idPembelian;
        }

        public List<(m_pembelian pembelian, m_detailpembelian detail, m_produk produk)> GetRiwayatPembelian()
        {
            List<(m_pembelian, m_detailpembelian, m_produk)> list = new();

            using var conn = new NpgsqlConnection(db.connstring);
            conn.Open();

            string query = @"
            SELECT 
                p.id_pembelian,
                p.tanggal_pembelian,
                p.nama_supplier,
                p.pembayaran_supplier,
                d.id_detailpembelian,
                d.jumlah_pembelian,
                d.id_produk,
                pr.nama_produk
            FROM pembelian p
            JOIN detail_pembelian d ON p.id_pembelian = d.id_pembelian
            JOIN produk pr ON pr.id_produk = d.id_produk
            ORDER BY p.id_pembelian DESC;
            ";

            using var cmd = new NpgsqlCommand(query, conn);
            using var dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var pembelian = new m_pembelian
                {
                    IdPembelian = dr.GetInt32(0),
                    TanggalPembelian = dr.GetDateTime(1),
                    NamaSupplier = dr.GetString(2),
                    PembayaranSupplier = dr.GetInt32(3)
                };

                var detail = new m_detailpembelian
                {
                    IdDetailPembelian = dr.GetInt32(4),
                    JumlahPembelian = dr.GetInt32(5),
                    IdProduk = dr.GetInt32(6),
                };

                var produk = new m_produk
                {
                    NamaProduk = dr.GetString(7)
                };

                list.Add((pembelian, detail, produk));
            }

            return list;
        }

    }
}
