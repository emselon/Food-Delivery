using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly bll_User _bll;

        public UserController(bll_User bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllUsers());
        }

        [HttpPost]
        public IActionResult Create(dto_User user)
        {
            return Ok(_bll.CreateUser(user));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_User user)
        {
            if (id != user.IdUser)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateUser(user));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteUser(id));
        }
    }
}
