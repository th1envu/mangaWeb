using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblChuong
{
    public int IdChuong { get; set; }

    public string? TenChuong { get; set; }

    public int IdTruyen { get; set; }

    public int ChuongSo { get; set; }
}
