using Npgsql;
using Project_Tanamin.app.dbconnect;
using System;

namespace Project_Tanamin.app.controller
{
    public class c_user
    {
        private string connString;
        private static int idUser;
        private static string namaLengkap;
        private static string username;
        private static string noTelp;
        private static string password;
        private static bool isAdmin;

        public static int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }

        public static string NamaLengkap
        {
            get { return namaLengkap; }
            set { namaLengkap = value; }
        }

        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        public static string NoTelp
        {
            get { return noTelp; }
            set { noTelp = value; }
        }

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        public static bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }

        public c_user()
        {
            connectdata db = new connectdata();
            connString = db.connstring;
        }

        public string Register(string namaLengkap, string username, string noTelp, string password, string konfirmasi)
        {
            if (string.IsNullOrWhiteSpace(namaLengkap) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(noTelp) ||
                string.IsNullOrWhiteSpace(password))
                return "Semua data harus diisi";

            if (password != konfirmasi)
                return "Konfirmasi password tidak cocok";


            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string checkQuery = "SELECT 1 FROM users WHERE username=@u LIMIT 1";

                using (NpgsqlCommand cmd = new NpgsqlCommand(checkQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);

                    var exists = cmd.ExecuteScalar();
                    if (exists != null)
                        return "Username telah digunakan";
                }

                string insertQuery = @" INSERT INTO users (nama_lengkap, username, no_telp, password, is_admin) VALUES (@nama, @user, @telp, @pass, false)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@nama", namaLengkap);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@telp", noTelp);
                    cmd.Parameters.AddWithValue("@pass", password);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Pendaftaran Berhasil";
        }

        public string Login(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                return "Username dan password harus diisi";

            string query = @"SELECT id_user, username, password, nama_lengkap, no_telp, is_admin FROM users WHERE username=@u AND password=@p LIMIT 1";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@u", user);
                cmd.Parameters.AddWithValue("@p", pass);

                conn.Open();

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        IdUser = reader.GetInt32(reader.GetOrdinal("id_user"));
                        Username = reader["username"].ToString();
                        Password = reader["password"].ToString();
                        NamaLengkap = reader["nama_lengkap"].ToString();
                        NoTelp = reader["no_telp"] == DBNull.Value ? "-" : reader["no_telp"].ToString();
                        IsAdmin = Convert.ToBoolean(reader["is_admin"]);

                        return IsAdmin ? "LOGIN_ADMIN" : "LOGIN_CUSTOMER";
                    }
                }
            }
            return "Koneksi Login Gagal";
        }

        /// <summary>
        /// Update profil user (nama, username, no_telp, password) berdasarkan id user.
        /// Mengembalikan pesan hasil operasi.
        /// </summary>
        public string UpdateProfile(int userId, string namaLengkapParam, string usernameParam, string noTelpParam, string passwordParam, string konfirmasi)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(namaLengkapParam) ||
                string.IsNullOrWhiteSpace(usernameParam) ||
                string.IsNullOrWhiteSpace(noTelpParam) ||
                string.IsNullOrWhiteSpace(passwordParam))
            {
                return "Semua data harus diisi";
            }

            if (passwordParam != konfirmasi)
                return "Konfirmasi password tidak cocok";

            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();

                    // Cek apakah username sudah dipakai oleh user lain
                    string checkQuery = "SELECT 1 FROM users WHERE username=@u AND id_user<>@id LIMIT 1";
                    using (NpgsqlCommand checkCmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@u", usernameParam);
                        checkCmd.Parameters.AddWithValue("@id", userId);
                        var exists = checkCmd.ExecuteScalar();
                        if (exists != null)
                            return "Username telah digunakan oleh user lain";
                    }

                    // Update data
                    string updateQuery = @"UPDATE users 
                                           SET nama_lengkap=@nama, username=@user, no_telp=@telp, password=@pass
                                           WHERE id_user=@id";

                    using (NpgsqlCommand updateCmd = new NpgsqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@nama", namaLengkapParam);
                        updateCmd.Parameters.AddWithValue("@user", usernameParam);
                        updateCmd.Parameters.AddWithValue("@telp", noTelpParam);
                        updateCmd.Parameters.AddWithValue("@pass", passwordParam);
                        updateCmd.Parameters.AddWithValue("@id", userId);

                        int rows = updateCmd.ExecuteNonQuery();
                        if (rows <= 0)
                            return "Gagal memperbarui data (tidak ada baris terpengaruh)";
                    }
                }

                // Jika sukses, update nilai-nilai static di aplikasi agar UI segera merefleksikan perubahan
                NamaLengkap = namaLengkapParam;
                Username = usernameParam;
                NoTelp = noTelpParam;
                Password = passwordParam;

                return "Update Profil Berhasil";
            }
            catch (Exception ex)
            {
                // Untuk debugging sementara bisa ditampilkan ex.Message; di production sebaiknya log error
                return "Terjadi kesalahan saat update: " + ex.Message;
            }
        }
    }
}
