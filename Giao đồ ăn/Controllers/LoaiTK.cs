using Microsoft.AspNetCore.Mvc;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoaiTaiKhoanController : ControllerBase
    {
        private readonly bll_LoaiTaiKhoan _bll;

        public LoaiTaiKhoanController(bll_LoaiTaiKhoan bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllLoaiTaiKhoan());
        }

        [HttpPost]
        public IActionResult Create(LoaiTaiKhoanDTO loai)
        {
            return Ok(_bll.CreateLoaiTaiKhoan(loai));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, LoaiTaiKhoanDTO loai)
        {
            if (id != loai.IdLoaiTaiKhoan)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateLoaiTaiKhoan(loai));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteLoaiTaiKhoan(id));
        }
    }
}
