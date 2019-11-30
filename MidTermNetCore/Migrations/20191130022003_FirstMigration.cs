using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MidTermNetCore.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khoas",
                columns: table => new
                {
                    MaKhoa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenKhoa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khoas", x => x.MaKhoa);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    MaMon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenMon = table.Column<string>(nullable: false),
                    SoTinChi = table.Column<int>(nullable: false),
                    MaKhoa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.MaMon);
                    table.ForeignKey(
                        name: "FK_MonHocs_Khoas_MaKhoa",
                        column: x => x.MaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SinhViens",
                columns: table => new
                {
                    MaSV = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoTen = table.Column<string>(maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(nullable: false),
                    DienThoai = table.Column<string>(maxLength: 11, nullable: true),
                    KhoaNavigationMaKhoa = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinhViens", x => x.MaSV);
                    table.ForeignKey(
                        name: "FK_SinhViens_Khoas_KhoaNavigationMaKhoa",
                        column: x => x.KhoaNavigationMaKhoa,
                        principalTable: "Khoas",
                        principalColumn: "MaKhoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LopHocPhans",
                columns: table => new
                {
                    MaLHP = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamHoc = table.Column<int>(nullable: false),
                    HocKy = table.Column<int>(nullable: false),
                    MonHocNavigationMaMon = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHocPhans", x => x.MaLHP);
                    table.ForeignKey(
                        name: "FK_LopHocPhans_MonHocs_MonHocNavigationMaMon",
                        column: x => x.MonHocNavigationMaMon,
                        principalTable: "MonHocs",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KetQuas",
                columns: table => new
                {
                    MaKetQua = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiemGK = table.Column<double>(nullable: false),
                    DiemCK = table.Column<double>(nullable: false),
                    SinhVienNavigationMaSV = table.Column<int>(nullable: true),
                    LopHocPhanNavigationMaLHP = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KetQuas", x => x.MaKetQua);
                    table.ForeignKey(
                        name: "FK_KetQuas_LopHocPhans_LopHocPhanNavigationMaLHP",
                        column: x => x.LopHocPhanNavigationMaLHP,
                        principalTable: "LopHocPhans",
                        principalColumn: "MaLHP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KetQuas_SinhViens_SinhVienNavigationMaSV",
                        column: x => x.SinhVienNavigationMaSV,
                        principalTable: "SinhViens",
                        principalColumn: "MaSV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_LopHocPhanNavigationMaLHP",
                table: "KetQuas",
                column: "LopHocPhanNavigationMaLHP");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuas_SinhVienNavigationMaSV",
                table: "KetQuas",
                column: "SinhVienNavigationMaSV");

            migrationBuilder.CreateIndex(
                name: "IX_LopHocPhans_MonHocNavigationMaMon",
                table: "LopHocPhans",
                column: "MonHocNavigationMaMon");

            migrationBuilder.CreateIndex(
                name: "IX_MonHocs_MaKhoa",
                table: "MonHocs",
                column: "MaKhoa");

            migrationBuilder.CreateIndex(
                name: "IX_SinhViens_KhoaNavigationMaKhoa",
                table: "SinhViens",
                column: "KhoaNavigationMaKhoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KetQuas");

            migrationBuilder.DropTable(
                name: "LopHocPhans");

            migrationBuilder.DropTable(
                name: "SinhViens");

            migrationBuilder.DropTable(
                name: "MonHocs");

            migrationBuilder.DropTable(
                name: "Khoas");
        }
    }
}
