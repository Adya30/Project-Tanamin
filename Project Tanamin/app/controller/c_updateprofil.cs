using Npgsql;
using Project_Tanamin.app.dbconnect;
using System;
using System.Collections.Generic;

namespace Project_Tanamin.app.controller
{
    public class c_updateprofil
    {
        private readonly string connString;

        public c_updateprofil()
        {
            connectdata db = new connectdata();
            connString = db.connstring;
        }

        private string ValidasiInput(string username, string password, string konfirmasi)
        {
            if (string.IsNullOrWhiteSpace(username))
                return "Username tidak boleh kosong";

            if (string.IsNullOrWhiteSpace(password))
                return "Password tidak boleh kosong";

            if (password != konfirmasi)
                return "Konfirmasi password tidak cocok";

            return "OK";
        }

        private bool UsernameSudahDipakai(NpgsqlConnection conn, string username)
        {
            string query = "SELECT 1 FROM users WHERE username=@u AND id_user <> @id LIMIT 1";
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@id", c_user.IdUser);
                return cmd.ExecuteScalar() != null;
            }
        }

        public string UpdateProfilAdmin(string username, string password, string konfirmasi)
        {
            string validasi = ValidasiInput(username, password, konfirmasi);
            if (validasi != "OK") return validasi;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                if (UsernameSudahDipakai(conn, username))
                    return "Username sudah digunakan!";

                string query = "UPDATE users SET username=@u, password=@p WHERE id_user=@id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.Parameters.AddWithValue("@id", c_user.IdUser);
                    cmd.ExecuteNonQuery();
                }
            }

            c_user.Username = username;
            c_user.Password = password;

            return "OK";
        }
       
    }
}
