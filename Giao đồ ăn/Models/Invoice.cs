using System;
using System.Collections.Generic;

namespace Giao_đồ_ăn.Models;

public partial class Invoice
{
    public int IdInvoice { get; set; }

    public int IdOrder { get; set; }

    public decimal SoTien { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayThanhToan { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
