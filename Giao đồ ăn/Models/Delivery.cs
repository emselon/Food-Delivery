using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class Delivery
{
    public int IdDelivery { get; set; }

    public int IdOrder { get; set; }

    public int IdShipper { get; set; }

    public DateTime? ThoiGianNhanHang { get; set; }

    public DateTime? ThoiGianDuKien { get; set; }

    public string? TrangThai { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Shipper IdShipperNavigation { get; set; } = null!;
}
