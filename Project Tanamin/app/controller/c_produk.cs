using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    //abstract
    public abstract class ProdukBaseController
    {
        protected readonly connectdata db;

        protected ProdukBaseController()
        {
            db = new connectdata();
        }

        // Abstraction: semua operasi CRUD harus diimplementasikan di subclass
        public abstract bool AddProduk(m_produk p);
        public abstract bool UpdateProduk(m_produk p);
        public abstract bool HapusProduk(int id);

        public virtual List<m_produk> GetProdukList()
        {
            var list = new List<m_produk>();
            try
            {
                using var conn = new NpgsqlConnection(db.connstring);
                conn.Open();
                string query = "SELECT * FROM produk";
                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new m_produk
                    {
                        IdProduk = reader.GetInt32(reader.GetOrdinal("id_produk")),
                        FotoProduk = reader["foto_produk"] == DBNull.Value ? null : (byte[])reader["foto_produk"],
                        NamaKategori = reader["nama_kategori"]?.ToString() ?? "",
                        NamaProduk = reader["nama_produk"]?.ToString() ?? "",
                        StokProduk = reader.GetInt32(reader.GetOrdinal("stok_produk")),
                        Deskripsi = reader["deskripsi"]?.ToString() ?? "",
                        HargaSatuan = reader.GetInt32(reader.GetOrdinal("harga_satuan")),
                        IsDeleted = reader.GetBoolean(reader.GetOrdinal("is_deleted"))
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error GetProdukList: " + ex.Message);
            }
            return list;
        }
    }

    //polymorphism
    public class c_produk : ProdukBaseController
    {
        // Override semua method abstrak
        public override bool AddProduk(m_produk p)
        {
            try
            {
                using var conn = new NpgsqlConnection(db.connstring);
                conn.Open();
                string query = @"
                    INSERT INTO produk (foto_produk, nama_kategori, nama_produk, stok_produk, deskripsi, harga_satuan, is_deleted)
                    VALUES (@foto, @kat, @nama, @stok, @desk, @harga, @isdel)";
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@foto", (object)p.FotoProduk ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@kat", p.NamaKategori ?? "");
                cmd.Parameters.AddWithValue("@nama", p.NamaProduk ?? "");
                cmd.Parameters.AddWithValue("@stok", p.StokProduk);
                cmd.Parameters.AddWithValue("@desk", p.Deskripsi ?? "");
                cmd.Parameters.AddWithValue("@harga", p.HargaSatuan);
                cmd.Parameters.AddWithValue("@isdel", p.StokProduk == 0);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error AddProduk: " + ex.Message);
                return false;
            }
        }

        public override bool UpdateProduk(m_produk p)
        {
            try
            {
                using var conn = new NpgsqlConnection(db.connstring);
                conn.Open();
                string query = @"
                    UPDATE produk 
                    SET foto_produk=@foto, nama_produk=@nama, nama_kategori=@kat, stok_produk=@stok, 
                        deskripsi=@desk, harga_satuan=@harga, is_deleted=@isdel
                    WHERE id_produk=@id";
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@foto", (object)p.FotoProduk ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nama", p.NamaProduk ?? "");
                cmd.Parameters.AddWithValue("@kat", p.NamaKategori ?? "");
                cmd.Parameters.AddWithValue("@stok", p.StokProduk);
                cmd.Parameters.AddWithValue("@desk", p.Deskripsi ?? "");
                cmd.Parameters.AddWithValue("@harga", p.HargaSatuan);
                cmd.Parameters.AddWithValue("@isdel", p.StokProduk == 0);
                cmd.Parameters.AddWithValue("@id", p.IdProduk);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error UpdateProduk: " + ex.Message);
                return false;
            }
        }

        public override bool HapusProduk(int id)
        {
            try
            {
                using var conn = new NpgsqlConnection(db.connstring);
                conn.Open();
                string query = "UPDATE produk SET stok_produk=0, is_deleted=true WHERE id_produk=@id";
                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error HapusProduk: " + ex.Message);
                return false;
            }
        }
    }
}
