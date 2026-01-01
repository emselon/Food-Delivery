namespace Giao_đồ_ăn.DTO
{
    public class TaiKhoanDTO
    {
        public int IdTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int IdLoaiTaiKhoan { get; set; }
        public DateTime NgayTao { get; set; }= DateTime.Now;
        public int? IdUser { get; set; }
        public int? IdShipper { get; set; }
        public int? IdRestaurant { get; set; }
        public bool TrangThai { get; set; } = true;
    }
}
