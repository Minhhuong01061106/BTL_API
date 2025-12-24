using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WebAPI_BTL_Admin.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LoaichitieuCtrl : ControllerBase
    {
        private readonly LoaichitieuBLL _bll;

        public LoaichitieuCtrl(LoaichitieuBLL bll)
        {
            _bll = bll;  // ← BLL đã được tạo sẵn với đầy đủ dependencies
        }

        [Route("Getall")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<LoaichitieuModel> data = _bll.GetAll();  // Sử dụng BLL
            return Ok(data);
        }

        [Route("Themloaichitieu")]
        [HttpPost]
        public IActionResult Create([FromBody]LoaichitieuModel model)
        {
            try
            {
                LoaichitieuModel loaichitieu = new LoaichitieuModel
                {
                    Tenloaichitieu = model.Tenloaichitieu,
                    Mota = model.Mota,
                    Trangthai = model.Trangthai,
                };

                bool ketqua = _bll.Create(loaichitieu);
                if (ketqua)
                {
                    // 201 Created + URL đến resource mới
                    return Created($"/api/loaichitieu/{loaichitieu.Idloaichitieu}", loaichitieu);
                }

                return BadRequest("Không thể tạo");  // 400
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");  // 500
            }
        }
    }
}
