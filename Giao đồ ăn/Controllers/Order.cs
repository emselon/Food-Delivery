using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly bll_Order _bll;

        public OrderController(bll_Order bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllOrders());
        }

        [HttpPost]
        public IActionResult Create(dto_Order order)
        {
            return Ok(_bll.CreateOrder(order));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_Order order)
        {
            if (id != order.IdOrder)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateOrder(order));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteOrder(id));
        }
    }
}
