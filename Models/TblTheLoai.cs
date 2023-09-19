using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblTheLoai
{
    public int IdTheLoai { get; set; }

    public string? TenTheLoai { get; set; }

    public string? MoTaTheLoai { get; set; }

    public virtual ICollection<TblTruyen> TblTruyens { get; set; } = new List<TblTruyen>();
}
