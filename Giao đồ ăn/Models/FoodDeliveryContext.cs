using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Giao_đồ_ăn.Models;

public partial class FoodDeliveryContext : DbContext
{
    public FoodDeliveryContext()
    {
    }

    public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<LoaiTaiKhoan> LoaiTaiKhoans { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-D716C2N8\\SQLEXPRESS;Database=FoodDelivery;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.IdDelivery).HasName("PK__Deliveri__77F64F5D87D8D896");

            entity.Property(e => e.ThoiGianDuKien).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianNhanHang).HasColumnType("datetime");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deliveries_Order");

            entity.HasOne(d => d.IdShipperNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdShipper)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Deliveries_Shipper");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.IdInvoice).HasName("PK__Invoices__4AFC50A4A4CBC907");

            entity.Property(e => e.NgayThanhToan).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(50);
            entity.Property(e => e.SoTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Invoices_Order");
        });

        modelBuilder.Entity<LoaiTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdLoaiTaiKhoan).HasName("PK__LoaiTaiK__CF914308FB1053AB");

            entity.ToTable("LoaiTaiKhoan");

            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenLoaiTaiKhoan).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.HasKey(e => e.IdMenuItem).HasName("PK__MenuItem__77CE2ED6DF14CA9E");

            entity.ToTable("MenuItem");

            entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenMon).HasMaxLength(150);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.IdRestaurantNavigation).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.IdRestaurant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MenuItem_Restaurant");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Orders__C38F3009812F8911");

            entity.Property(e => e.DiaChiGiao).HasMaxLength(255);
            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhiVanChuyen).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.IdRestaurantNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdRestaurant)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Restaurant");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.IdOrderItem).HasName("PK__OrderIte__65E8C2F3F061345E");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdMenuItemNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.IdMenuItem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_MenuItem");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_Order");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.IdRestaurant).HasName("PK__Restaura__311D1D13FCCCB26C");

            entity.ToTable("Restaurant");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenRestaurant).HasMaxLength(150);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.IdShipper).HasName("PK__Shipper__86F2CAD27117756D");

            entity.ToTable("Shipper");

            entity.Property(e => e.BienSoXe).HasMaxLength(20);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoan).HasName("PK__TaiKhoan__9A53D3DD59AAEA3F");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC080AD644A").IsUnique();

            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TenDangNhap).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);

            entity.HasOne(d => d.IdLoaiTaiKhoanNavigation).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.IdLoaiTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaiKhoan_LoaiTaiKhoan");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__UserInfo__B7C926388406059D");

            entity.ToTable("UserInfo");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
