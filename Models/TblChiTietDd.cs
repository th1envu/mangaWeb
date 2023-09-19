using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblChiTietDd
{
    public int MaChiTietDd { get; set; }

    public string? UserName { get; set; }

    public int? IdTruyen { get; set; }

    public int? SoLuong { get; set; }

    public int? MaDonDat { get; set; }

    public virtual TblUser? UserNameNavigation { get; set; }
}
