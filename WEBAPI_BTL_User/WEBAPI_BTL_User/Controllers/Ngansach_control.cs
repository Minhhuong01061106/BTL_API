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
    }
}
