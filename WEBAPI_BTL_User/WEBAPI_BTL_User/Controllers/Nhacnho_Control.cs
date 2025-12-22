using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WEBAPI_BTL_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Nhacnho_Control : ControllerBase
    {
        private readonly Nhacnho_BLL _bll;
        public Nhacnho_Control(IConfiguration config)
        {
            string connStr = config.GetConnectionString("DefaultConnection");
            _bll = new Nhacnho_BLL(connStr);
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult Getall()
        {
            try
            {
                List<Nhacnho> data =  _bll.GetAllNhacNho();
                return Ok(data);
            }
            catch (Exception ex)
            { 
                return StatusCode(500, new {
                    message = ex.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }
        [Route("GetidNhacnho")]
        [HttpGet]
        public IActionResult Getbyid(int id) 
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest(new
                    {
                        message = "Id không hợp lệ"
                    });
                }
                Nhacnho data = _bll.Getbyidnhacnho(id);
                if (data == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy nhắc nhở"
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
    }
}
