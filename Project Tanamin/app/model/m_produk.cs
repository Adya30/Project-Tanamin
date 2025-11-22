using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tanamin.app.model
{
    public class m_produk
    {
        public int id_produk { get; set; }       
        public string nama_produk { get; set; }    
        public int stok_produk { get; set; }     
        public string deskripsi { get; set; }   
        public bool is_deleted { get; set; }  
        public int? id_kategoriproduk { get; set; }
    }
}
