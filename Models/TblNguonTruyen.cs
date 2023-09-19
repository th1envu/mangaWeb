using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblNguonTruyen
{
    public int IdNguon { get; set; }

    public string? TenNguon { get; set; }

    public string? LinkNguon { get; set; }

    public virtual ICollection<TblTruyen> TblTruyens { get; set; } = new List<TblTruyen>();
}
