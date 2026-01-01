namespace Giao_đồ_ăn.DTO
{
    public class LoaiTaiKhoanDTO
    {
        public int IdLoaiTaiKhoan { get; set; }
        public string TenLoaiTaiKhoan { get; set; }
        public string MoTa { get; set; }
        public bool TrangThai { get; set; } = true;
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
