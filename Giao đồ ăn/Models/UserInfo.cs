using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class UserInfo
{
    public int IdUser { get; set; }

    public string HoTen { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
