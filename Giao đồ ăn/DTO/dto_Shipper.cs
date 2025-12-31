using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class dto_Shipper
    {
        public int IdShipper { get; set; }

        public string HoTen { get; set; } = null!;

        public string? SoDienThoai { get; set; }

        public string? BienSoXe { get; set; }

        public bool? TrangThai { get; set; }

        public DateTime? NgayTao { get; set; }
    }
}
