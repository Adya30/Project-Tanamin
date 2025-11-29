using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_PembayaranSupplier
    {
        private readonly connectdata db;

        public c_PembayaranSupplier()
        {
            db = new connectdata();
        }

        public bool ProsesPembayaranSupplier(int? userId, List<(m_produk produk, int jumlah)> keranjang, string supplierName)
        {
            try
            {
                using var conn = new NpgsqlConnection(db.connstring);
                conn.Open();
                using var tran = conn.BeginTransaction();

                // Tambah stok produk sesuai keranjang
                foreach (var item in keranjang)
                {
                    string query = @"
                        UPDATE produk
                        SET stok_produk = stok_produk + @jumlah
                        WHERE id_produk = @id_produk";
                    using var cmd = new NpgsqlCommand(query, conn, tran);
                    cmd.Parameters.AddWithValue("@jumlah", item.jumlah);
                    cmd.Parameters.AddWithValue("@id_produk", item.produk.IdProduk);
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal proses pembayaran supplier: " + ex.Message);
                return false;
            }
        }
    }
}
