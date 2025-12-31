using Microsoft.AspNetCore.Mvc;
using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.BLL;
namespace Giao_đồ_ăn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly bll_Shipper _bll;

        // Constructor inject DAL
        public ShipperController(bll_Shipper bll)
        {
            _bll = bll;
        }
        [HttpGet]
        [Route("get-all")]
        public IActionResult Get()
        {
            var Shipper = _bll.GetAllShippers();
            return Ok(Shipper);

        }

    }
}
