using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WEBAPI_BTL_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Ngansach_control : ControllerBase
    {
        private readonly Ngansach_BLL _bll;

        public Ngansach_control(IConfiguration configuration)
        {
            string connStr = configuration.GetConnectionString("DefaultConnection");
            _bll = new Ngansach_BLL(connStr);
        }

        // GET: api/ngansach_control/get-all
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            try
            {
                List<Ngansach> data = _bll.GetAllNganSach();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public IActionResult Getbyid(int id) 
        {
            try
            {
                Ngansach data = _bll.GetNganSachById(id);
                if (data == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy ngân sách với id = " + id
                    });
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        [Route("ThemNgansach")]
        [HttpPost]
        public IActionResult Themngansach([FromBody] Ngansach ns)
        {
            try
            {
                if(ns == null)
                {
                    return BadRequest( new {message="Dữ liệu không hợp lệ"});
                }
                bool result = _bll.Themngansach(ns);

                if (!result)
                {
                    return BadRequest(new { message = "Thêm ngân sách thất bại" });
                }

                return Ok(new
                {
                    message = "Thêm ngân sách thành công"
                });
            }
            catch(Exception ex) 
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
