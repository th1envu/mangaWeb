using MessagePack;
using System;
using System.Collections.Generic;

namespace WebTruyenTranh.Models
{
    public class ChiTietTruyen
    {
        public int IdTruyen { get; set; }

        public string? TenTruyen { get; set; }

        public string? TacGia { get; set; }

        public string? AnhDaiDien { get; set; }

        public string? TinhTrang { get; set; }

        public int? IdNguon { get; set; }

        public string? MoTa { get; set; }

        public DateTime? NgayDang { get; set; }

        public string? TheLoaiTruyen { get; set; }

        public int? IdNxb { get; set; }

        public int? IdTheLoai { get; set; }

        public virtual TblTheLoai? IdNguon1 { get; set; }

        public virtual TblNguonTruyen? IdNguonNavigation { get; set; }

        public virtual TblNxb? IdNxbNavigation { get; set; }
        public int IdChuong { get; set; }

        public string? TenChuong { get; set; }

        public int ChuongSo { get; set; }
    }
}
