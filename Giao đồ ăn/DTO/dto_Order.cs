namespace Giao_đồ_ăn.DTO
{
    public class dto_Order
    {
        public int IdOrder { get; set; }
        public int IdUser { get; set; }
        public int IdRestaurant { get; set; }
        public decimal TongTien { get; set; }
        public decimal PhiVanChuyen { get; set; }
        public string TrangThai { get; set; }
        public string DiaChiGiao { get; set; }
        public DateTime NgayDat { get; set; }
    }
}
