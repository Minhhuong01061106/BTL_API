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
                        message = "Không tìm ID thấy nhắc nhở"
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
        [Route("Themnhacnho")]
        [HttpPost]
        public IActionResult Themnhacnho([FromBody] Nhacnho nn)
        {
            try
            {
                if (nn == null)
                {
                    return NotFound(new
                    {
                        message = "KHông có dữ liệu"
                    });
                }
                bool result = _bll.Themnhacnho(nn);
                if (!result)
                {
                    return BadRequest(new
                    {
                        message = "Thêm nhắc nhở thất bại"
                    });
                }
                return Ok(new
                {
                    message = "Thêm nhắc nhở thành công"
                });


            }
            catch (Exception e)
            {
                return StatusCode(500, new 
                { 
                    message = e.Message,
                    stackTrace = e.StackTrace
                });

            }
        }
        [Route("Suanhacnho")]
        [HttpPut]
        public IActionResult Suanhacnho([FromBody] Nhacnho nn)
        {
            try
            {
                if (nn == null)
                {
                    return NotFound(new
                    {
                        message = "Dữ liệu không hợp lệ"
                    });
                }
                if (nn.IdNhacNho <= 0)
                {
                    return BadRequest(new
                    {
                        message = "Id nhắc nhở không hợp lệ"
                    });
                }
                bool result = _bll.Suanhacnho(nn);
                if (!result)
                {
                    return BadRequest(new
                    {
                        message = "Sửa nhắc nhở không hợp lệ"
                    });
                }
                return Ok(new
                {
                    message = " Sửa nhắc nhở thành công"
                });

            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
        [Route("Xoanhacnho")]
        [HttpDelete]
        public IActionResult Xoanhacnho(int id) 
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        message = "Id nhắc nhở không hợp lệ"
                    });
                }
                bool result = _bll.Xoanhacnho(id);
                if (!result)
                {
                    return BadRequest(new
                    {
                        message = "Không tìm thấy nhắc nhở để xóa"
                    });
                }
                return Ok(new
                {
                    message = "Xóa nhắc nhở thành công"
                });
            }
            catch(Exception e) 
            {
                return StatusCode(500, new
                {
                    message = e.Message,
                    stackTrace = e.StackTrace
                });
            }
        }
    }
}
