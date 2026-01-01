using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly bll_MenuItem _bll;

        public MenuItemController(bll_MenuItem bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllMenuItems());
        }

        [HttpPost]
        public IActionResult Create(dto_MenuItem item)
        {
            return Ok(_bll.CreateMenuItem(item));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_MenuItem item)
        {
            if (id != item.IdMenuItem)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateMenuItem(item));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteMenuItem(id));
        }
    }
}
