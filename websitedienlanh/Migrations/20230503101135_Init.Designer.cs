﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using websitedienlanh.Data;

#nullable disable

namespace websitedienlanh.Migrations
{
    [DbContext(typeof(websitedienlanhContext))]
    [Migration("20230503101135_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("websitedienlanh.Models.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"), 1L, 1);

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerID");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("websitedienlanh.Models.ChiTietDatHang", b =>
                {
                    b.Property<int>("ChiTietDatHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietDatHangID"), 1L, 1);

                    b.Property<int>("DonDatHangID")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("ChiTietDatHangID");

                    b.HasIndex("DonDatHangID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ChiTietDatHang");
                });

            modelBuilder.Entity("websitedienlanh.Models.DanhMuc", b =>
                {
                    b.Property<int>("DanhMucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhMucID"), 1L, 1);

                    b.Property<int>("LoaiDanhMucID")
                        .HasColumnType("int");

                    b.Property<string>("TenDanhMuc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhMucID");

                    b.ToTable("DanhMuc");
                });

            modelBuilder.Entity("websitedienlanh.Models.DonDatHang", b =>
                {
                    b.Property<int>("DonDatHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonDatHangID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("DonDatHangID");

                    b.ToTable("DonDatHang");
                });

            modelBuilder.Entity("websitedienlanh.Models.HinhAnh", b =>
                {
                    b.Property<int>("HinhAnhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhAnhID"), 1L, 1);

                    b.Property<string>("Active")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("HinhAnhID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("HinhAnh");
                });

            modelBuilder.Entity("websitedienlanh.Models.LoaiDanhMuc", b =>
                {
                    b.Property<int>("LoaiDanhMucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiDanhMucID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiDanhMucID");

                    b.ToTable("LoaiDanhMuc");
                });

            modelBuilder.Entity("websitedienlanh.Models.MoTa", b =>
                {
                    b.Property<int>("MoTaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MoTaID"), 1L, 1);

                    b.Property<string>("NoiDungMoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("MoTaID");

                    b.ToTable("MoTa");
                });

            modelBuilder.Entity("websitedienlanh.Models.QuyenHan", b =>
                {
                    b.Property<int>("QuyenHanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenHanID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenHanID");

                    b.ToTable("QuyenHan");
                });

            modelBuilder.Entity("websitedienlanh.Models.SanPham", b =>
                {
                    b.Property<int>("SanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamID"), 1L, 1);

                    b.Property<int>("DanhMucID")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThuongHieuID")
                        .HasColumnType("int");

                    b.HasKey("SanPhamID");

                    b.HasIndex("DanhMucID");

                    b.HasIndex("ThuongHieuID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("websitedienlanh.Models.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenHanID")
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenHanID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("websitedienlanh.Models.ThongSo", b =>
                {
                    b.Property<int>("ThongSoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongSoID"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<string>("TenThongSo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThongSoID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ThongSo");
                });

            modelBuilder.Entity("websitedienlanh.Models.ThuongHieu", b =>
                {
                    b.Property<int>("ThuongHieuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThuongHieuID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThuongHieuID");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("websitedienlanh.Models.ChiTietDatHang", b =>
                {
                    b.HasOne("websitedienlanh.Models.DonDatHang", "DonDatHang")
                        .WithMany()
                        .HasForeignKey("DonDatHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websitedienlanh.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDatHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("websitedienlanh.Models.HinhAnh", b =>
                {
                    b.HasOne("websitedienlanh.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("websitedienlanh.Models.SanPham", b =>
                {
                    b.HasOne("websitedienlanh.Models.DanhMuc", "DanhMuc")
                        .WithMany()
                        .HasForeignKey("DanhMucID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("websitedienlanh.Models.ThuongHieu", "ThuongHieu")
                        .WithMany()
                        .HasForeignKey("ThuongHieuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("ThuongHieu");
                });

            modelBuilder.Entity("websitedienlanh.Models.TaiKhoan", b =>
                {
                    b.HasOne("websitedienlanh.Models.QuyenHan", "QuyenHan")
                        .WithMany()
                        .HasForeignKey("QuyenHanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("QuyenHan");
                });

            modelBuilder.Entity("websitedienlanh.Models.ThongSo", b =>
                {
                    b.HasOne("websitedienlanh.Models.SanPham", "SanPham")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
