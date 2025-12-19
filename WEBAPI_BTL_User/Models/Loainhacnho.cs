using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Loainhacnho
    {
        public int IdLoaiNhacNho { get; set; }      
        public string TenLoaiNhacNho { get; set; }  
        public string MoTa { get; set; }            
        public bool TrangThai { get; set; }         
        public DateTime NgayTao { get; set; }
    }
}
