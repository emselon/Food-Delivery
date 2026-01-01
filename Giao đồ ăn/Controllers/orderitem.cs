using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private readonly bll_OrderItem _bll;

        public OrderItemController(bll_OrderItem bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllOrderItems());
        }

        [HttpPost]
        public IActionResult Create(dto_OrderItem item)
        {
            return Ok(_bll.CreateOrderItem(item));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_OrderItem item)
        {
            if (id != item.IdOrderItem)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateOrderItem(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteOrderItem(id));
        }
    }
}
