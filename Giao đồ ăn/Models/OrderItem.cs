using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class OrderItem
{
    public int IdOrderItem { get; set; }

    public int IdOrder { get; set; }

    public int IdMenuItem { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public decimal ThanhTien { get; set; }

    public virtual MenuItem IdMenuItemNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
