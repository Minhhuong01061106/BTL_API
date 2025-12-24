using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class NhacnhoModel
    {
        public int Idnhacnho { get; set; }
        public int Idtaikhoan { get; set; }
        public int Idloainhacnho { get; set; }
        public string Noidung { get; set; } = string.Empty;
        public float Sotiennhacnho { get; set; }
        public string Chukynhacnho { get; set; } = string.Empty;
        public DateTime Ngayketthuc { get; set; }
        public string Mota { get; set; } = string.Empty;
        public bool Trangthai { get; set; }
    }
}
