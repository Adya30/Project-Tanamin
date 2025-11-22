using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tanamin.app.model
{
    public class m_user
    {
        public int id_user { get; set; }
        public string username { get; set; }
        public string passwords { get; set; }
        public string nama_lengkap { get; set; }
        public string no_telp { get; set; }
        public bool is_admin { get; set; }

    }

}