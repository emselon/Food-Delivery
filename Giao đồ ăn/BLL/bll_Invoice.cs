using DTO;
using FoodDeliveryAPI.DAL;
using Giao_đồ_ăn.DTO;

namespace Giao_đồ_ăn.BLL
{
    public class bll_Invoice
    {
        private readonly InvoiceDAL _dal = new InvoiceDAL();

        public List<dto_Invoice> GetAllInvoices() => _dal.GetAllInvoices();

        public bool CreateInvoice(dto_Invoice invoice) => _dal.CreateInvoice(invoice);

        public bool UpdateInvoice(dto_Invoice invoice) => _dal.UpdateInvoice(invoice);

        public bool DeleteInvoice(int id) => _dal.DeleteInvoice(id);
    }
}
