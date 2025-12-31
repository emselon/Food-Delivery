using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class LoaiTaiKhoan
{
    public int IdLoaiTaiKhoan { get; set; }

    public string TenLoaiTaiKhoan { get; set; } = null!;

    public string? MoTa { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<TaiKhoan> TaiKhoans { get; set; } = new List<TaiKhoan>();
}
