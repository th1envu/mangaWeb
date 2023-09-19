using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblHoaDon
{
    public int MaHoaDon { get; set; }

    public DateTime? NgayLap { get; set; }

    public string? UserName { get; set; }

    public double? TongTien { get; set; }

    public int? IdNhanVien { get; set; }

    public string? GhiChu { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public virtual TblUser? UserNameNavigation { get; set; }
}
