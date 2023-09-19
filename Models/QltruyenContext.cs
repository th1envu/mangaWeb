using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebTruyenTranh.Models;

public partial class QltruyenContext : DbContext
{
    public QltruyenContext()
    {
    }

    public QltruyenContext(DbContextOptions<QltruyenContext> options)
        : base(options)
    {
    }
    public virtual DbSet<TblChiTietDd> TblChiTietDds { get; set; }

    public virtual DbSet<TblChiTietHd> TblChiTietHds { get; set; }

    public virtual DbSet<TblChiTietPn> TblChiTietPns { get; set; }

    public virtual DbSet<TblChuong> TblChuongs { get; set; }

    public virtual DbSet<TblChuongHinhAnh> TblChuongHinhAnhs { get; set; }

    public virtual DbSet<TblDonDat> TblDonDats { get; set; }

    public virtual DbSet<TblHoaDon> TblHoaDons { get; set; }

    public virtual DbSet<TblNguonTruyen> TblNguonTruyens { get; set; }

    public virtual DbSet<TblNxb> TblNxbs { get; set; }

    public virtual DbSet<TblPhieuNhap> TblPhieuNhaps { get; set; }

    public virtual DbSet<TblTheLoai> TblTheLoais { get; set; }

    public virtual DbSet<TblTruyen> TblTruyens { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CAU-BANH\\SQLEXPRESS;Initial Catalog=qltruyen;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblChiTietDd>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDd);

            entity.ToTable("tbl_ChiTietDD");

            entity.Property(e => e.MaChiTietDd).HasColumnName("maChiTietDD");
            entity.Property(e => e.IdTruyen).HasColumnName("idTruyen");
            entity.Property(e => e.MaDonDat).HasColumnName("maDonDat");
            entity.Property(e => e.SoLuong).HasColumnName("soLuong");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("userName");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblChiTietDds)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_ChiTietDD_tbl_User");
        });

        modelBuilder.Entity<TblChiTietHd>(entity =>
        {
            entity.HasKey(e => new { e.MaChiTietHd, e.IdTruyen });

            entity.ToTable("tbl_ChiTietHD");

            entity.Property(e => e.MaChiTietHd)
                .ValueGeneratedOnAdd()
                .HasColumnName("maChiTietHD");
            entity.Property(e => e.IdTruyen).HasColumnName("idTruyen");
            entity.Property(e => e.GiaTruyen).HasColumnName("giaTruyen");
            entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");
        });

        modelBuilder.Entity<TblChiTietPn>(entity =>
        {
            entity.HasKey(e => e.MaChiTietPn).HasName("PK_tbl_ChiTietPN1");

            entity.ToTable("tbl_ChiTietPN");

            entity.Property(e => e.MaChiTietPn).HasColumnName("maChiTietPN");
            entity.Property(e => e.GiaTruyen).HasColumnName("giaTruyen");
            entity.Property(e => e.IdTruyen).HasColumnName("idTruyen");
            entity.Property(e => e.MaPhieuNhap).HasColumnName("maPhieuNhap");
            entity.Property(e => e.SoLuongTk).HasColumnName("soLuongTK");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("userName");
        });

        modelBuilder.Entity<TblChuong>(entity =>
        {
            entity.HasKey(e => new { e.IdChuong, e.IdTruyen, e.ChuongSo }).HasName("PK_tbl_Chuong1");

            entity.ToTable("tbl_Chuong");

            entity.Property(e => e.IdChuong)
                .ValueGeneratedOnAdd()
                .HasColumnName("idChuong");
            entity.Property(e => e.IdTruyen).HasColumnName("idTruyen");
            entity.Property(e => e.ChuongSo).HasColumnName("chuongSo");
            entity.Property(e => e.TenChuong)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("tenChuong");
        });

        modelBuilder.Entity<TblChuongHinhAnh>(entity =>
        {
            entity.HasKey(e => new { e.IdAnh, e.SoAnh }).HasName("PK_tbl_ChuongAnh");

            entity.ToTable("tbl_Chuong_HinhAnh");

            entity.Property(e => e.IdAnh)
                .ValueGeneratedOnAdd()
                .HasColumnName("idAnh");
            entity.Property(e => e.SoAnh).HasColumnName("soAnh");
            entity.Property(e => e.IdChuong).HasColumnName("idChuong");
            entity.Property(e => e.LinkAnh)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("linkAnh");
            entity.Property(e => e.TenAnh)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("tenAnh");
        });

        modelBuilder.Entity<TblDonDat>(entity =>
        {
            entity.HasKey(e => e.MaDonDat);

            entity.ToTable("tbl_DonDat");

            entity.Property(e => e.MaDonDat).HasColumnName("maDonDat");
            entity.Property(e => e.NgayDat)
                .HasColumnType("datetime")
                .HasColumnName("ngayDat");
        });

        modelBuilder.Entity<TblHoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon);

            entity.ToTable("tbl_HoaDon");

            entity.Property(e => e.MaHoaDon).HasColumnName("maHoaDon");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("ghiChu");
            entity.Property(e => e.IdNhanVien).HasColumnName("idNhanVien");
            entity.Property(e => e.NgayLap)
                .HasColumnType("datetime")
                .HasColumnName("ngayLap");
            entity.Property(e => e.PhuongThucThanhToan)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("phuongThucThanhToan");
            entity.Property(e => e.TongTien).HasColumnName("tongTien");
            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("userName");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.TblHoaDons)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_tbl_HoaDon_tbl_User");
        });

        modelBuilder.Entity<TblNguonTruyen>(entity =>
        {
            entity.HasKey(e => e.IdNguon);

            entity.ToTable("tbl_NguonTruyen");

            entity.Property(e => e.IdNguon).HasColumnName("idNguon");
            entity.Property(e => e.LinkNguon)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("linkNguon");
            entity.Property(e => e.TenNguon)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("tenNguon");
        });

        modelBuilder.Entity<TblNxb>(entity =>
        {
            entity.HasKey(e => e.IdNxb);

            entity.ToTable("tbl_NXB");

            entity.Property(e => e.IdNxb).HasColumnName("idNXB");
            entity.Property(e => e.TenNxb)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("tenNXB");
        });

        modelBuilder.Entity<TblPhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap);

            entity.ToTable("tbl_PhieuNhap");

            entity.Property(e => e.MaPhieuNhap).HasColumnName("maPhieuNhap");
            entity.Property(e => e.GhiChu)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("ghiChu");
            entity.Property(e => e.MaDonDat).HasColumnName("maDonDat");
            entity.Property(e => e.NgayNhap)
                .HasColumnType("datetime")
                .HasColumnName("ngayNhap");
            entity.Property(e => e.TongTien).HasColumnName("tongTien");
        });

        modelBuilder.Entity<TblTheLoai>(entity =>
        {
            entity.HasKey(e => e.IdTheLoai);

            entity.ToTable("tbl_TheLoai");

            entity.Property(e => e.IdTheLoai).HasColumnName("idTheLoai");
            entity.Property(e => e.MoTaTheLoai)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasColumnName("moTaTheLoai");
            entity.Property(e => e.TenTheLoai)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("tenTheLoai");
        });

        modelBuilder.Entity<TblTruyen>(entity =>
        {
            entity.HasKey(e => e.IdTruyen);

            entity.ToTable("tbl_Truyen");

            entity.Property(e => e.IdTruyen).HasColumnName("idTruyen");
            entity.Property(e => e.AnhDaiDien)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("anhDaiDien");
            entity.Property(e => e.IdNguon).HasColumnName("idNguon");
            entity.Property(e => e.IdNxb).HasColumnName("idNXB");
            entity.Property(e => e.IdTheLoai).HasColumnName("idTheLoai");
            entity.Property(e => e.MoTa)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("moTa");
            entity.Property(e => e.NgayDang)
                .HasColumnType("datetime")
                .HasColumnName("ngayDang");
            entity.Property(e => e.TacGia)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("tacGia");
            entity.Property(e => e.TenTruyen)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("tenTruyen");
            entity.Property(e => e.TheLoaiTruyen)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("theLoaiTruyen");
            entity.Property(e => e.TinhTrang)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("tinhTrang");

            entity.HasOne(d => d.IdNguonNavigation).WithMany(p => p.TblTruyens)
                .HasForeignKey(d => d.IdNguon)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_Truyen_tbl_NguonTruyen1");

            entity.HasOne(d => d.IdNguon1).WithMany(p => p.TblTruyens)
                .HasForeignKey(d => d.IdNguon)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_Truyen_tbl_TheLoai");

            entity.HasOne(d => d.IdNxbNavigation).WithMany(p => p.TblTruyens)
                .HasForeignKey(d => d.IdNxb)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_tbl_Truyen_tbl_NXB");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("tbl_User");

            entity.Property(e => e.UserName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("userName");
            entity.Property(e => e.IsAdmin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("isAdmin");
            entity.Property(e => e.PassWord)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("passWord");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
