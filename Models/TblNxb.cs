using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblNxb
{
    public int IdNxb { get; set; }

    public string? TenNxb { get; set; }

    public virtual ICollection<TblTruyen> TblTruyens { get; set; } = new List<TblTruyen>();
}
