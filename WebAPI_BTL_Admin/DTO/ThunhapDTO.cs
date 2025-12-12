using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThunhapDTO
    {
        public int IdThuNhap { get; set; }          
        public string TenThuNhap { get; set; } = string.Empty;
        public int IdTaiKhoan { get; set; }       
        public int IdLoaiThuNhap { get; set; }    
        public float SoTien { get; set; }        
        public DateTime NgayThuNhap { get; set; }  
        public DateTime NgayTao { get; set; }      
        public string MoTa { get; set; } = string.Empty;
        public bool TrangThai { get; set; }
    }
}
