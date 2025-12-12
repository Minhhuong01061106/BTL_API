using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NgansachDTO
    {
        public int Idngansach { get; set; }
        public int Idtaikhoan { get; set; }
        public string Tenngansach { get; set; } = string.Empty;
        public float Sotiengioihan { get; set; }
        public string Mota { get; set; } = string.Empty;
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
