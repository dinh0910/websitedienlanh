﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websitedienlanh.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    BannerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.BannerID);
                });

			migrationBuilder.CreateTable(
	name: "LoaiDanhMuc",
	columns: table => new
	{
		LoaiDanhMucID = table.Column<int>(type: "int", nullable: false)
			.Annotation("SqlServer:Identity", "1, 1"),
		Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
	},
	constraints: table =>
	{
		table.PrimaryKey("PK_LoaiDanhMuc", x => x.LoaiDanhMucID);
	});

			migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    DanhMucID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiDanhMucID = table.Column<int>(type: "int", nullable: false),
                    TenDanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMuc", x => x.DanhMucID);
					table.ForeignKey(
	                    name: "FK_DanhMuc_LoaiDanhMuc_LoaiDanhMucID",
	                    column: x => x.LoaiDanhMucID,
	                    principalTable: "LoaiDanhMuc",
	                    principalColumn: "LoaiDanhMucID",
	                    onDelete: ReferentialAction.Cascade);
				    });

            migrationBuilder.CreateTable(
                name: "DonDatHang",
                columns: table => new
                {
                    DonDatHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonDatHang", x => x.DonDatHangID);
                });





            migrationBuilder.CreateTable(
                name: "QuyenHan",
                columns: table => new
                {
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyenHan", x => x.QuyenHanID);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieu",
                columns: table => new
                {
                    ThuongHieuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieu", x => x.ThuongHieuID);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuyenHanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.TaiKhoanID);
                    table.ForeignKey(
                        name: "FK_TaiKhoan_QuyenHan_QuyenHanID",
                        column: x => x.QuyenHanID,
                        principalTable: "QuyenHan",
                        principalColumn: "QuyenHanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    SanPhamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhMucID = table.Column<int>(type: "int", nullable: false),
                    ThuongHieuID = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.SanPhamID);
                    table.ForeignKey(
                        name: "FK_SanPham_DanhMuc_DanhMucID",
                        column: x => x.DanhMucID,
                        principalTable: "DanhMuc",
                        principalColumn: "DanhMucID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SanPham_ThuongHieu_ThuongHieuID",
                        column: x => x.ThuongHieuID,
                        principalTable: "ThuongHieu",
                        principalColumn: "ThuongHieuID",
                        onDelete: ReferentialAction.Cascade);
                });

			migrationBuilder.CreateTable(
	name: "MoTa",
	columns: table => new
	{
		MoTaID = table.Column<int>(type: "int", nullable: false)
			.Annotation("SqlServer:Identity", "1, 1"),
		SanPhamID = table.Column<int>(type: "int", nullable: false),
		NoiDungMoTa = table.Column<string>(type: "nvarchar(max)", nullable: true)
	},
	constraints: table =>
	{
		table.PrimaryKey("PK_MoTa", x => x.MoTaID);
		table.ForeignKey(
			name: "FK_MoTa_SanPham_SanPhamID",
			column: x => x.SanPhamID,
			principalTable: "SanPham",
			principalColumn: "SanPhamID",
			onDelete: ReferentialAction.Cascade);
	});

			migrationBuilder.CreateTable(
                name: "ChiTietDatHang",
                columns: table => new
                {
                    ChiTietDatHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonDatHangID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDatHang", x => x.ChiTietDatHangID);
                    table.ForeignKey(
                        name: "FK_ChiTietDatHang_DonDatHang_DonDatHangID",
                        column: x => x.DonDatHangID,
                        principalTable: "DonDatHang",
                        principalColumn: "DonDatHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietDatHang_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HinhAnh",
                columns: table => new
                {
                    HinhAnhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhAnh", x => x.HinhAnhID);
                    table.ForeignKey(
                        name: "FK_HinhAnh_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongSo",
                columns: table => new
                {
                    ThongSoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    TenThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSo", x => x.ThongSoID);
                    table.ForeignKey(
                        name: "FK_ThongSo_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatHang_DonDatHangID",
                table: "ChiTietDatHang",
                column: "DonDatHangID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDatHang_SanPhamID",
                table: "ChiTietDatHang",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HinhAnh_SanPhamID",
                table: "HinhAnh",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_DanhMucID",
                table: "SanPham",
                column: "DanhMucID");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_ThuongHieuID",
                table: "SanPham",
                column: "ThuongHieuID");

            migrationBuilder.CreateIndex(
                name: "IX_TaiKhoan_QuyenHanID",
                table: "TaiKhoan",
                column: "QuyenHanID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSo_SanPhamID",
                table: "ThongSo",
                column: "SanPhamID");

			migrationBuilder.CreateIndex(
	            name: "IX_DanhMuc_LoaiDanhMucID",
	            table: "DanhMuc",
	            column: "LoaiDanhMucID");

			migrationBuilder.CreateIndex(
	            name: "IX_MoTa_SanPhamID",
	            table: "MoTa",
	            column: "SanPhamID");
		}

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "ChiTietDatHang");

            migrationBuilder.DropTable(
                name: "HinhAnh");

            migrationBuilder.DropTable(
                name: "LoaiDanhMuc");

            migrationBuilder.DropTable(
                name: "MoTa");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "ThongSo");

            migrationBuilder.DropTable(
                name: "DonDatHang");

            migrationBuilder.DropTable(
                name: "QuyenHan");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "ThuongHieu");
        }
    }
}
