using Microsoft.AspNetCore.Mvc;
using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly bll_Restaurant _bll;

        // Constructor inject BLL
        public RestaurantController(bll_Restaurant bll)
        {
            _bll = bll;
        }

        // GET: api/restaurant/get-all
        [HttpGet]
        [Route("get-all")]
        public IActionResult Get()
        {
            var restaurants = _bll.GetAllRestaurants();
            return Ok(restaurants);
        }

        // POST: api/restaurant/create
        [HttpPost("create")]
        public IActionResult Create([FromBody] dto_restaurant restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _bll.CreateRestaurant(restaurant);

            if (result)
                return Ok("Thêm nhà hàng thành công");

            return BadRequest("Thêm nhà hàng thất bại");
        }

        // DELETE: api/restaurant/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _bll.DeleteRestaurant(id);

            if (result)
                return Ok(new { message = "Xóa nhà hàng thành công!" });

            return NotFound(new { message = "Không tìm thấy nhà hàng!" });
        }

        // PUT: api/restaurant/update/{id}
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] dto_restaurant restaurant)
        {
            if (id != restaurant.IdRestaurant)
                return BadRequest("ID không khớp");

            bool result = _bll.UpdateRestaurant(restaurant);

            if (result)
                return Ok("Cập nhật nhà hàng thành công");

            return NotFound("Không tìm thấy nhà hàng");
        }
    }
}
