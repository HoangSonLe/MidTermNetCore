﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MidTermNetCore.Models;

namespace MidTermNetCore.Migrations
{
    [DbContext(typeof(MyDBContext))]
    partial class MyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MidTermNetCore.Models.KetQua", b =>
                {
                    b.Property<int>("MaKetQua")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiemCK");

                    b.Property<double>("DiemGK");

                    b.Property<int?>("LopHocPhanNavigationMaLHP");

                    b.Property<int?>("SinhVienNavigationMaSV");

                    b.HasKey("MaKetQua");

                    b.HasIndex("LopHocPhanNavigationMaLHP");

                    b.HasIndex("SinhVienNavigationMaSV");

                    b.ToTable("KetQuas");
                });

            modelBuilder.Entity("MidTermNetCore.Models.Khoa", b =>
                {
                    b.Property<int>("MaKhoa")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TenKhoa")
                        .IsRequired();

                    b.HasKey("MaKhoa");

                    b.ToTable("Khoas");
                });

            modelBuilder.Entity("MidTermNetCore.Models.LopHocPhan", b =>
                {
                    b.Property<int>("MaLHP")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HocKy");

                    b.Property<int?>("MonHocNavigationMaMon");

                    b.Property<int>("NamHoc");

                    b.HasKey("MaLHP");

                    b.HasIndex("MonHocNavigationMaMon");

                    b.ToTable("LopHocPhans");
                });

            modelBuilder.Entity("MidTermNetCore.Models.MonHoc", b =>
                {
                    b.Property<int>("MaMon")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MaKhoa");

                    b.Property<int>("SoTinChi");

                    b.Property<string>("TenMon")
                        .IsRequired();

                    b.HasKey("MaMon");

                    b.HasIndex("MaKhoa");

                    b.ToTable("MonHocs");
                });

            modelBuilder.Entity("MidTermNetCore.Models.SinhVien", b =>
                {
                    b.Property<int>("MaSV")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DienThoai")
                        .HasMaxLength(11);

                    b.Property<string>("HoTen")
                        .HasMaxLength(50);

                    b.Property<int?>("KhoaNavigationMaKhoa");

                    b.Property<DateTime>("NgaySinh");

                    b.HasKey("MaSV");

                    b.HasIndex("KhoaNavigationMaKhoa");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("MidTermNetCore.Models.KetQua", b =>
                {
                    b.HasOne("MidTermNetCore.Models.LopHocPhan", "LopHocPhanNavigation")
                        .WithMany("KetQuas")
                        .HasForeignKey("LopHocPhanNavigationMaLHP");

                    b.HasOne("MidTermNetCore.Models.SinhVien", "SinhVienNavigation")
                        .WithMany("KetQuas")
                        .HasForeignKey("SinhVienNavigationMaSV");
                });

            modelBuilder.Entity("MidTermNetCore.Models.LopHocPhan", b =>
                {
                    b.HasOne("MidTermNetCore.Models.MonHoc", "MonHocNavigation")
                        .WithMany("LopHocPhans")
                        .HasForeignKey("MonHocNavigationMaMon");
                });

            modelBuilder.Entity("MidTermNetCore.Models.MonHoc", b =>
                {
                    b.HasOne("MidTermNetCore.Models.Khoa", "KhoaNavigation")
                        .WithMany("MonHocs")
                        .HasForeignKey("MaKhoa");
                });

            modelBuilder.Entity("MidTermNetCore.Models.SinhVien", b =>
                {
                    b.HasOne("MidTermNetCore.Models.Khoa", "KhoaNavigation")
                        .WithMany("SinhViens")
                        .HasForeignKey("KhoaNavigationMaKhoa");
                });
#pragma warning restore 612, 618
        }
    }
}