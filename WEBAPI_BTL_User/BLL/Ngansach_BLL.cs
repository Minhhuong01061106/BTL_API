using DAL;
using Models;

namespace BLL
{
    public class Ngansach_BLL
    {
        private readonly Ngansach_DAL _dal;

        public Ngansach_BLL(string connectionString)
        {
            _dal = new Ngansach_DAL(connectionString);
        }

        public List<Ngansach> GetAllNganSach()
        {
            return _dal.GetAllNganSach();
        }
    }
}
