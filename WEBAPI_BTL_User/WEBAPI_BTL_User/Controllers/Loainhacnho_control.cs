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
        [Route("Themloainn")]
        [HttpPost]
        public IActionResult Themloainhacnho([FromBody] Loainhacnho lnn)
        {
            try
            {
                if (lnn == null)
                {
                    return NotFound(new
                    {
                        message = "Dữ liệu ko hợp lệ"
                    });
                }
                bool result = _bll.Themloainhacnho(lnn);
                if (result)
                {
                    return Ok(new
                    {
                        message = "Thêm loại nhắc nhở thành công"
                    });
                }
                return BadRequest(new
                {
                    message = "Thêm loại nhắc nhở thất bại"
                });
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
        [Route("Sualoainhacnho")]
        [HttpPut]
        public IActionResult Sualoainhacnho([FromBody] Loainhacnho lnn)
        {
            try
            {
                if (lnn == null)
                {
                    return NotFound(new
                    {
                        message = "Dữ liệu không hợp lệ"
                    });
                }
                if (lnn.IdLoaiNhacNho <= 0) 
                {
                    return BadRequest(new
                    {
                        message = "Id loại nhắc nhở không hợp lệ"
                    });
                }
                bool result = _bll.Sualoainhacnho(lnn);
                if (!result) 
                {
                    return BadRequest(new
                    {
                        message = "KHông tìm thấy dữ liệu loại nhắc nhở "
                    });
                }
                return Ok(new
                {
                    message = "Sửa loại nhắc nhở thành công"
                });

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
        [Route("Xoaloainn")]
        [HttpDelete]
        public IActionResult Xoaloainn( int id) 
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest(new
                    {
                        message = "Id không hợp lệ"

                    });
                }
                bool result = _bll.Xoaloainhacnho(id);
                if (!result)
                {
                    return BadRequest(new
                    {
                        message = "Không tìm thấy id ngân sách để xóa"
                    });
                }
                return Ok(new
                {
                    message = "Xóa loại nhắc nhở thành công"
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
    }
}
