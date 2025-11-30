using System;

namespace Project_Tanamin.app.model
{
    public class m_pembelian
    {
        public int IdPembelian { get; set; }
        public DateTime TanggalPembelian { get; set; }
        public string NamaSupplier { get; set; }
        public int PembayaranSupplier { get; set; }

    }
}
