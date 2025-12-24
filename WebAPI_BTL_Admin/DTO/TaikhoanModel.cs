using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TaikhoanModel
    {
        public int Idtaikhoan { get; set; }
        public string Tendangnhap { get; set; } = string.Empty;
        public string Matkhau { get; set; } = string.Empty;
        public int Idloaitaikhoan { get; set; }
        public bool Trangthai { get; set; }
    }
}
