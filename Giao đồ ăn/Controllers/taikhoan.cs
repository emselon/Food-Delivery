using Microsoft.AspNetCore.Mvc;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaiKhoanController : ControllerBase
    {
        private readonly bll_TaiKhoan _bll;

        public TaiKhoanController(bll_TaiKhoan bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_bll.GetAllTaiKhoan());

        [HttpPost]
        public IActionResult Create(TaiKhoanDTO tk) => Ok(_bll.CreateTaiKhoan(tk));

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaiKhoanDTO tk)
        {
            if (id != tk.IdTaiKhoan) return BadRequest("ID không khớp");
            return Ok(_bll.UpdateTaiKhoan(tk));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_bll.DeleteTaiKhoan(id));
    }
}
