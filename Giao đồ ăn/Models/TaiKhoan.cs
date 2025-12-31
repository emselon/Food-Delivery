using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class TaiKhoan
{
    public int IdTaiKhoan { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int IdLoaiTaiKhoan { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual LoaiTaiKhoan IdLoaiTaiKhoanNavigation { get; set; } = null!;
}
