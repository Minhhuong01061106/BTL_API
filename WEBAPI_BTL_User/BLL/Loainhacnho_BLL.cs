using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class Loainhacnho_BLL
    {
        private readonly Loainhacnho_DAL _dal;

        // Khởi tạo BLL và truyền chuỗi kết nối xuống DAL
        public Loainhacnho_BLL(string connectionString)
        {
            _dal = new Loainhacnho_DAL(connectionString);
        }
        public List<Loainhacnho> GetAllLoaiNhacNho()
        {
            return _dal.GetAllLoaiNhacNho();
        }
        public Loainhacnho GetLoaiNhacNhoById(int idLoaiNhacNho)
        {
            return _dal.GetLoaiNhacNhoById(idLoaiNhacNho);
        }
    }
}
