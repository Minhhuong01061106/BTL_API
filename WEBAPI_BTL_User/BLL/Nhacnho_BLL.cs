using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class Nhacnho_BLL
    {
        private readonly Nhacnho_DAL _dal;
        public Nhacnho_BLL(string connectionString)
        {
            _dal = new Nhacnho_DAL(connectionString);
        }
        public List<Nhacnho> GetAllNhacNho()
        {
            return _dal.GetAllNhacNho();
        }
        public Nhacnho Getbyidnhacnho(int idnhacnho)
        {
            return _dal.Getbyidnhacnho(idnhacnho);
        }
    }
}
