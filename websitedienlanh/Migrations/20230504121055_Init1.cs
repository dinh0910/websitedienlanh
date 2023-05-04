using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace websitedienlanh.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DonViTinh",
                columns: table => new
                {
                    DonViTinhID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinh", x => x.DonViTinhID);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    NhaCungCapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.NhaCungCapID);
                });

            migrationBuilder.CreateTable(
                name: "NhapHang",
                columns: table => new
                {
                    NhapHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoanID = table.Column<int>(type: "int", nullable: false),
                    NhaCungCapID = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhapHang", x => x.NhapHangID);
                    table.ForeignKey(
                        name: "FK_NhapHang_NhaCungCap_NhaCungCapID",
                        column: x => x.NhaCungCapID,
                        principalTable: "NhaCungCap",
                        principalColumn: "NhaCungCapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NhapHang_TaiKhoan_TaiKhoanID",
                        column: x => x.TaiKhoanID,
                        principalTable: "TaiKhoan",
                        principalColumn: "TaiKhoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietNhapHang",
                columns: table => new
                {
                    ChiTietNhapHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NhapHangID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    DonViTinhID = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ThanhTien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietNhapHang", x => x.ChiTietNhapHangID);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHang_DonViTinh_DonViTinhID",
                        column: x => x.DonViTinhID,
                        principalTable: "DonViTinh",
                        principalColumn: "DonViTinhID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHang_NhapHang_NhapHangID",
                        column: x => x.NhapHangID,
                        principalTable: "NhapHang",
                        principalColumn: "NhapHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietNhapHang_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_DonViTinhID",
                table: "ChiTietNhapHang",
                column: "DonViTinhID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_NhapHangID",
                table: "ChiTietNhapHang",
                column: "NhapHangID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietNhapHang_SanPhamID",
                table: "ChiTietNhapHang",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHang_NhaCungCapID",
                table: "NhapHang",
                column: "NhaCungCapID");

            migrationBuilder.CreateIndex(
                name: "IX_NhapHang_TaiKhoanID",
                table: "NhapHang",
                column: "TaiKhoanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DanhMuc_LoaiDanhMuc_LoaiDanhMucID",
                table: "DanhMuc");

            migrationBuilder.DropTable(
                name: "ChiTietNhapHang");

            migrationBuilder.DropTable(
                name: "DonViTinh");

            migrationBuilder.DropTable(
                name: "NhapHang");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.AlterColumn<string>(
                name: "HinhAnh",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Active",
                table: "Banner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
