using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public int IdRestaurant { get; set; }

    public decimal TongTien { get; set; }

    public decimal? PhiVanChuyen { get; set; }

    public string? TrangThai { get; set; }

    public string? DiaChiGiao { get; set; }

    public DateTime? NgayDat { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual Restaurant IdRestaurantNavigation { get; set; } = null!;

    public virtual UserInfo IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
