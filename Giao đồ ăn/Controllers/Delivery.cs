using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : ControllerBase
    {
        private readonly bll_Delivery _bll;

        public DeliveryController(bll_Delivery bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllDeliveries());
        }

        [HttpPost]
        public IActionResult Create(dto_Delivery delivery)
        {
            return Ok(_bll.CreateDelivery(delivery));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_Delivery delivery)
        {
            if (id != delivery.IdDelivery)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateDelivery(delivery));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteDelivery(id));
        }
    }
}
