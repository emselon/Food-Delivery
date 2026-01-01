namespace Giao_đồ_ăn.DTO
{
    public class dto_MenuItem
    {
        public int IdMenuItem { get; set; }
        public int IdRestaurant { get; set; }
        public string TenMon { get; set; }
        public decimal Gia { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
