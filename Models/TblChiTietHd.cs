using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblChiTietHd
{
    public int MaChiTietHd { get; set; }

    public int IdTruyen { get; set; }

    public int? MaHoaDon { get; set; }

    public double? GiaTruyen { get; set; }
}
