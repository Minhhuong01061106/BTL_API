using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserInfoDTO
    {
        public int IdUser { get; set; }
        public string Tentaikhoan { get; set; } = string.Empty;  
        public DateTime Ngaysinh { get; set; }   
        public string Diachi { get; set; } = string.Empty;
        public string Mota { get; set; } = string.Empty;
        public bool Trangthai { get; set; }    
        public int Idtaikhoan { get; set; }
    }
}
