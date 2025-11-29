using Project_Tanamin.app.model;
using Project_Tanamin.app.dbconnect;
using Npgsql;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_feedback
    {
        private readonly string connString;

        public c_feedback()
        {
            var db = new connectdata();
            connString = db.connstring;
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connString);
        }

        public bool TambahFeedback(string pertanyaan, DateTime tanggal)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();

                string query = @"INSERT INTO feedback (pertanyaan, id_user, tanggal_feedback)
                                 VALUES (@p, @uid, @tgl)";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p", pertanyaan);
                cmd.Parameters.AddWithValue("@uid", c_user.CurrentUser.IdUser);
                cmd.Parameters.AddWithValue("@tgl", tanggal);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error TambahFeedback: " + ex.Message);
                return false;
            }
        }

        public bool UpdateFeedback(string oldTanggal, string oldPertanyaan, DateTime newTanggal, string newPertanyaan)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();

                string query = @"UPDATE feedback SET pertanyaan=@newP, tanggal_feedback=@newT
                                 WHERE id_user=@uid AND pertanyaan=@oldP AND tanggal_feedback=@oldT";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@newP", newPertanyaan);
                cmd.Parameters.AddWithValue("@newT", newTanggal);
                cmd.Parameters.AddWithValue("@oldP", oldPertanyaan);
                cmd.Parameters.AddWithValue("@oldT", DateTime.Parse(oldTanggal));
                cmd.Parameters.AddWithValue("@uid", c_user.CurrentUser.IdUser);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error UpdateFeedback: " + ex.Message);
                return false;
            }
        }

        public bool DeleteFeedback(string tanggal, string pertanyaan)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();

                string query = @"DELETE FROM feedback
                                 WHERE id_user=@uid AND pertanyaan=@p AND tanggal_feedback=@t";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@uid", c_user.CurrentUser.IdUser);
                cmd.Parameters.AddWithValue("@p", pertanyaan);
                cmd.Parameters.AddWithValue("@t", DateTime.Parse(tanggal));

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error DeleteFeedback: " + ex.Message);
                return false;
            }
        }

        public bool AddResponse(int id_feedback, string respon)
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();

                string query = @"UPDATE feedback SET respon=@r WHERE id_feedback=@id";

                using var cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@r", respon);
                cmd.Parameters.AddWithValue("@id", id_feedback);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error AddResponse: " + ex.Message);
                return false;
            }
        }

        public List<Feedback> GetCustomerFeedback()
        {
            var list = new List<Feedback>();

            using var conn = GetConnection();
            conn.Open();

            string query = @"SELECT * FROM feedback WHERE id_user=@uid ORDER BY id_feedback DESC";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@uid", c_user.CurrentUser.IdUser);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(ReadFeedback(reader));

            return list;
        }

        public List<Feedback> GetAllFeedback()
        {
            var list = new List<Feedback>();

            using var conn = GetConnection();
            conn.Open();

            string query = @"SELECT * FROM feedback ORDER BY id_feedback DESC";
            using var cmd = new NpgsqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(ReadFeedback(reader));

            return list;
        }

        private Feedback ReadFeedback(NpgsqlDataReader reader)
        {
            return new Feedback
            {
                id_feedback = reader.GetInt32(reader.GetOrdinal("id_feedback")),
                id_user = reader["id_user"] as int?,
                pertanyaan = reader["pertanyaan"].ToString(),
                respon = reader["respon"] as string,
                tanggal_feedback = (DateTime)reader["tanggal_feedback"]
            };
        }
    }
}
