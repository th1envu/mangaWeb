using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblChiTietPn
{
    public int MaChiTietPn { get; set; }

    public int? MaPhieuNhap { get; set; }

    public int? SoLuongTk { get; set; }

    public int? IdTruyen { get; set; }

    public double? GiaTruyen { get; set; }

    public string? UserName { get; set; }
}
