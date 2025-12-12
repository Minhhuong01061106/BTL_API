using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaichitieuDTO
    {
        public int Idloaichitieu { get; set; }
        public string Tenloaichitieu { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
