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
        [HttpPost("create")]
        public IActionResult Create([FromBody] dto_Shipper shipper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _bll.CreateShipper(shipper);

            if (result)
                return Ok("Thêm shipper thành công");

            return BadRequest("Thêm thất bại");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShipper(int id)
        {
            bool result = _bll.XoaShipper(id);

            if (result)
            {
                return Ok(new { message = "Xóa shipper thành công!" });
            }
            else
            {
                return NotFound(new { message = "Không tìm thấy shipper!" });
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] dto_Shipper shipper)
        {
            if (id != shipper.IdShipper)
                return BadRequest("ID không khớp");

            bool result = _bll.UpdateShipper(shipper);

            if (result)
                return Ok("Cập nhật shipper thành công");

            return NotFound("Không tìm thấy shipper");
        }


    }
}
