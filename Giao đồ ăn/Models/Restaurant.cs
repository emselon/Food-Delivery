using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class Restaurant
{
    public int IdRestaurant { get; set; }

    public string TenRestaurant { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
