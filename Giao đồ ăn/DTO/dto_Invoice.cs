namespace Giao_đồ_ăn.DTO
{
    public class dto_Invoice
    {
        public int IdInvoice { get; set; }
        public int IdOrder { get; set; }
        public decimal SoTien { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public bool TrangThai { get; set; }
        public DateTime? NgayThanhToan { get; set; }
    }
}
