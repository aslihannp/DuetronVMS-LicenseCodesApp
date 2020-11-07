using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.Entities
{
   public class SalesTable
    {
        public int ULC;
        public int UC { get; set; }
        public string ClientName { get; set; }
        public int Camera { get; set; }
        public int NVR { get; set; }
        public int VideoDuvar;
        public int IsIstasyonu { get; set; }
        public int Keyboard { get; set; }
        public DateTime SatisTarihi;
        public string LisansKodu { get; set; }
        public string DonanimID { get; set; }
        public string Notes { get; set; }
    }
}
