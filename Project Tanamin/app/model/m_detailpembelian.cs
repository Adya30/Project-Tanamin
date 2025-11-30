using System;

namespace Project_Tanamin.app.model
{
    public class m_detailpembelian
    {
        public int IdDetailPembelian { get; set; }
        public int JumlahPembelian { get; set; }
        public int? IdProduk { get; set; }
        public int IdPembelian { get; set; }
        public string? NamaProduk { get; set; }
    }
}
