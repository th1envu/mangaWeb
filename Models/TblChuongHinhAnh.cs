using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblChuongHinhAnh
{
    public int IdAnh { get; set; }

    public int SoAnh { get; set; }

    public int? IdChuong { get; set; }

    public string? LinkAnh { get; set; }

    public string? TenAnh { get; set; }
}
