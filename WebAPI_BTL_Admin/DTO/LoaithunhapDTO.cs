using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaithunhapDTO
    {
        public int Idloaithunhap { get; set; }
        public int IdTaikhoan { get; set; }
        public string Tenloaithunhap { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
