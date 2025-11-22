using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Tanamin.app.model
{
    public class m_feedback
    {
        public int id_feedback { get; set; }
        public string laporan { get; set; }
        public string respon { get; set; }
        public int? id_user { get; set; }
    }

}
