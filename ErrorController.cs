using Microsoft.AspNetCore.Mvc;

namespace KitapTakip.Controllers
{
    [ApiController]
    [Route("error")]
    public class ErrorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Error()
        {
            return StatusCode(500, "Bir hata oluştu.");
        }
    }
} 