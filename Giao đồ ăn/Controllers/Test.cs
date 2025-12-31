using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Hello API");
        }
    }
}
