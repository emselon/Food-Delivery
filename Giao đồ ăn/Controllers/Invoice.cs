using DTO;
using Giao_đồ_ăn.BLL;
using Giao_đồ_ăn.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Giao_đồ_ăn.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly bll_Invoice _bll;

        public InvoiceController(bll_Invoice bll)
        {
            _bll = bll;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bll.GetAllInvoices());
        }

        [HttpPost]
        public IActionResult Create(dto_Invoice invoice)
        {
            return Ok(_bll.CreateInvoice(invoice));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, dto_Invoice invoice)
        {
            if (id != invoice.IdInvoice)
                return BadRequest("ID không khớp");

            return Ok(_bll.UpdateInvoice(invoice));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bll.DeleteInvoice(id));
        }
    }
}
