namespace Giao_đồ_ăn.DTO
{
    public class dto_OrderItem
    {
        public int IdOrderItem { get; set; }
        public int IdOrder { get; set; }
        public int IdMenuItem { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
