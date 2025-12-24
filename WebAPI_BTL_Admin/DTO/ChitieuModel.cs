using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChitieuModel
    {
        public int Idchitieu { get; set; }
        public string Tenchitieu { get; set; }
        public int Idtaikhoan { get; set; }
        public int Idloaichitieu { get; set; }
        public float Sotien { get; set; }
        public DateTime Ngaychitieu { get; set; }
        public string Mota { get; set; }
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
