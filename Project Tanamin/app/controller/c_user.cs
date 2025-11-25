using Npgsql;
using Project_Tanamin.app.dbconnect;
using Project_Tanamin.app.model;
using System;

namespace Project_Tanamin.app.controller
{
    public class c_user
    {
        private readonly string connString;

        public c_user()
        {
            connectdata db = new connectdata();
            connString = db.connstring;
        }

        public static User CurrentUser { get; private set; }

        public string RegisterCustomer(string nama, string username, string telp, string password, string konfirmasi)
        {
            if (string.IsNullOrWhiteSpace(nama) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(telp) ||
                string.IsNullOrWhiteSpace(password))
                return "Semua data harus diisi";

            if (password != konfirmasi)
                return "Konfirmasi password tidak cocok";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string checkQuery = "SELECT 1 FROM users WHERE username=@u LIMIT 1";
                using (var cmd = new NpgsqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    if (cmd.ExecuteScalar() != null)
                        return "Username sudah digunakan";
                }

                string insertQuery = @"INSERT INTO users 
                    (nama_lengkap, username, no_telp, password, is_admin)
                    VALUES (@nama, @user, @telp, @pass, false)";

                using (var cmd = new NpgsqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@telp", telp);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteNonQuery();
                }
            }

            return "Pendaftaran Berhasil";

        }

        public string Login(string username, string password)
        {
            string query = @"SELECT id_user, username, password, nama_lengkap, no_telp, is_admin FROM users WHERE username=@u AND password=@p LIMIT 1";

            using (var conn = new NpgsqlConnection(connString))
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        bool isAdmin = Convert.ToBoolean(reader["is_admin"]);

                        User akun = isAdmin ? new Admin() : new Customer();

                        akun.IdUser = reader.GetInt32(reader.GetOrdinal("id_user"));
                        akun.Username = reader["username"].ToString();
                        akun.Password = reader["password"].ToString();

                        if (!isAdmin)
                        {
                            akun.NamaLengkap = reader["nama_lengkap"].ToString();
                            akun.NoTelp = reader["no_telp"]?.ToString();
                        }

                        CurrentUser = akun;

                        return isAdmin ? "LOGIN_ADMIN" : "LOGIN_CUSTOMER";
                    }
                }
            }

            return "LOGIN_GAGAL";
        }

        public string UpdateProfile(string nama, string username, string telp, string pass, string konfirmasi)
        {
            if (CurrentUser == null)
                return "Tidak ada user login";

            if (CurrentUser.IsAdmin)
            {
                return UpdateAdmin(username, pass, konfirmasi);
            }
            else
            {
                return UpdateCustomer(nama, username, telp, pass, konfirmasi);
            }
        }

        private string UpdateCustomer(string nama, string username, string telp, string pass, string konfirmasi)
        {
            if (string.IsNullOrWhiteSpace(nama) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(telp) ||
                string.IsNullOrWhiteSpace(pass))
                return "Semua data harus diisi";

            if (pass != konfirmasi)
                return "Konfirmasi password tidak cocok";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string updateQuery = @"UPDATE users SET nama_lengkap=@nama, username=@user, no_telp=@telp, password=@pass WHERE id_user=@id";

                using (var cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@telp", telp);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@id", CurrentUser.IdUser);
                    cmd.ExecuteNonQuery();
                }
            }

            CurrentUser.NamaLengkap = nama;
            CurrentUser.Username = username;
            CurrentUser.NoTelp = telp;
            CurrentUser.Password = pass;

            return "Update Profil Berhasil";
        }

        private string UpdateAdmin(string username, string pass, string konfirmasi)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(pass))
                return "Username dan password harus diisi";

            if (pass != konfirmasi)
                return "Konfirmasi password tidak cocok";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string updateQuery = @"UPDATE users SET username=@user,password=@pass WHERE id_user=@id";

                using (var cmd = new NpgsqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.Parameters.AddWithValue("@id", CurrentUser.IdUser);
                    cmd.ExecuteNonQuery();
                }
            }

            CurrentUser.Username = username;
            CurrentUser.Password = pass;

            return "Update Profil Berhasil";
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
