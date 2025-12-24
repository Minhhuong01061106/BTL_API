using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class LoaichitieuModel
    {
        [JsonIgnore]
        public int Idloaichitieu { get; set; }
        public string Tenloaichitieu { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public bool Trangthai { get; set; }
        [JsonIgnore]
        public DateTime Ngaytao { get; set; }
        
    }
}
