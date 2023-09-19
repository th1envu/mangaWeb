using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models;

public partial class TblUser
{
    public string UserName { get; set; } = null!;

    public string? PassWord { get; set; }

    public string? IsAdmin { get; set; }

    public virtual ICollection<TblChiTietDd> TblChiTietDds { get; set; } = new List<TblChiTietDd>();

    public virtual ICollection<TblHoaDon> TblHoaDons { get; set; } = new List<TblHoaDon>();
}
