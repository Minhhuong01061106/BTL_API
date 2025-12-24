using DAL;
using Models;
namespace BLL
{
    public class LoaichitieuBLL
    {
        private readonly LoaichitieuDAL _dal;

        public LoaichitieuBLL(LoaichitieuDAL dal)
        {
            _dal = dal;
        }

        public List<LoaichitieuModel> GetAll()
        {
            return _dal.getall();
        }
        public bool Create(LoaichitieuModel model)
        {
            return _dal.Create(model);
        }
    }
}
