using Project_Tanamin.app.model;

namespace Project_Tanamin
{
    internal static class Program
    {
        public static List<(m_produk produk, int jumlah)> KeranjangBelanja = new List<(m_produk produk, int jumlah)>();

        // Simulasi user yang login (sesuaikan saat autentikasi)
        public static int? userLoginId = 1; // misal user id 1

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new v_login());
        }
    }
}


