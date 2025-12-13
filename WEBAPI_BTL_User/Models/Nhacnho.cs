using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Nhacnho
    {
        public int IdNhacNho { get; set; }         
        public int IdTaiKhoan { get; set; }         
        public int IdLoaiNhacNho { get; set; }      
        public string NoiDung { get; set; }         
        public decimal SoTienNhacNho { get; set; }  
        public string ChuKyNhacNho { get; set; }    
        public DateTime? NgayKetThuc { get; set; }  
        public string MoTa { get; set; }           
        public bool TrangThai { get; set; }
    }
}
