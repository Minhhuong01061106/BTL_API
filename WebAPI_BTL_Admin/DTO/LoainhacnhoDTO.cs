using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoainhacnhoDTO
    {
        public int Idloainhacnho { get; set; }
        public string Tenloainhacnho { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public DateTime Ngaytao { get; set; }
        public bool Trangthai { get; set; }
    }
}
