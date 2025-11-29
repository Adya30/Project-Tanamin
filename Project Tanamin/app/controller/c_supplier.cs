using Npgsql;
using Project_Tanamin.app.dbconnect;
using System;

namespace Project_Tanamin.app.controller
{
    public class c_supplier
    {
        private readonly connectdata db;

        public c_supplier()
        {
            db = new connectdata(); 
        }

        public bool InsertPembayaran(DateTime tanggal, string namaSupplier, decimal nominal)
        {
            try
            {
                using (var conn = db.getConn())
                {
                    conn.Open();
                    string query = @"INSERT INTO pembayaran_supplier 
                                     (tanggal, nama_supplier, nominal)
                                     VALUES (@tanggal, @nama, @nominal)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tanggal", tanggal);
                        cmd.Parameters.AddWithValue("@nama", namaSupplier);
                        cmd.Parameters.AddWithValue("@nominal", nominal);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("InsertPembayaran ERROR: " + ex.Message);
                return false;
            }
        }
    }
}
