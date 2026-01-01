namespace Giao_đồ_ăn.DTO
{
    public class dto_Delivery
    {
        public int IdDelivery { get; set; }
        public int IdOrder { get; set; }
        public int IdShipper { get; set; }
        public DateTime? ThoiGianNhanHang { get; set; }
        public DateTime? ThoiGianDuKien { get; set; }
        public string TrangThai { get; set; }
    }
}
