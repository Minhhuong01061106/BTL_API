using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace WEBAPI_BTL_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loainhacnho_control: ControllerBase
    {
        private readonly Loainhacnho_BLL _bll;

        public Loainhacnho_control(IConfiguration config)
        {
            string connStr = config.GetConnectionString("DefaultConnection");
            _bll = new Loainhacnho_BLL(connStr);
        }

        [Route("GetAll")]
        [HttpGet]

        public IActionResult GetALL()
        {
            try
            {
                List<Loainhacnho> data = _bll.GetAllLoaiNhacNho();
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
        [Route("Get-id-lnn/{id}")]
        [HttpGet]
        public IActionResult Getbyid(int id)
        {
            try
            {
                Loainhacnho data = _bll.GetLoaiNhacNhoById(id);
                if (data == null)
                {
                    return NotFound(new
                    {
                        message = "Không tìm thấy loại nhắc nhở với id = " + id
                    });
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = ex.Message
                });
            }
        }
    }
}
