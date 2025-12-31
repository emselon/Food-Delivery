using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class MenuItem
{
    public int IdMenuItem { get; set; }

    public int IdRestaurant { get; set; }

    public string TenMon { get; set; } = null!;

    public decimal Gia { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual Restaurant IdRestaurantNavigation { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
