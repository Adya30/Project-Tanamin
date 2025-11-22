using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tanamin.app.model
{
    public class m_kecamatan
    {
        public int id_kecamatan { get; set; }
        public string nama_kecamatan { get; set; }
        public int? id_kabupaten { get; set; }
    }

}
