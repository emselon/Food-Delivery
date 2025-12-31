using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class Shipper
{
    public int IdShipper { get; set; }

    public string HoTen { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? BienSoXe { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
