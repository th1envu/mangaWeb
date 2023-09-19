using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblPhieuNhap
{
    public int MaPhieuNhap { get; set; }

    public DateTime? NgayNhap { get; set; }

    public double? TongTien { get; set; }

    public string? GhiChu { get; set; }

    public int? MaDonDat { get; set; }
}
