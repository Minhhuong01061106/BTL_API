using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ngansach
    {
        public int IdNganSach { get; set; }         
        public int IdTaiKhoan { get; set; }         
        public string TenNganSach { get; set; }    
        public decimal SoTienGioiHan { get; set; }  
        public string MoTa { get; set; }          
        public DateTime NgayTao { get; set; }      
        public bool TrangThai { get; set; }
    }
}
