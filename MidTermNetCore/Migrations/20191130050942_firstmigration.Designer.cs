﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MidTermNetCore.Models;

namespace MidTermNetCore.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20191130050942_firstmigration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DiemCK");

                    b.Property<double>("DiemGK");

                    b.Property<int>("HocKy");

                    b.Property<int>("MaLHP");

                    b.Property<int?>("MaMon");

                    b.Property<int?>("MaSV");

                    b.Property<int>("NamHoc");

                    b.HasKey("ID");

                    b.HasIndex("MaMon");

                    b.HasIndex("MaSV");

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

                    b.Property<int?>("MaKhoa");

                    b.Property<DateTime>("NgaySinh");

                    b.HasKey("MaSV");

                    b.HasIndex("MaKhoa");

                    b.ToTable("SinhViens");
                });

            modelBuilder.Entity("MidTermNetCore.Models.LopHocPhan", b =>
                {
                    b.HasOne("MidTermNetCore.Models.MonHoc", "MonHocNavigation")
                        .WithMany()
                        .HasForeignKey("MaMon");

                    b.HasOne("MidTermNetCore.Models.SinhVien", "SinhVienNavigation")
                        .WithMany()
                        .HasForeignKey("MaSV");
                });

            modelBuilder.Entity("MidTermNetCore.Models.MonHoc", b =>
                {
                    b.HasOne("MidTermNetCore.Models.Khoa", "KhoaNavigation")
                        .WithMany()
                        .HasForeignKey("MaKhoa");
                });

            modelBuilder.Entity("MidTermNetCore.Models.SinhVien", b =>
                {
                    b.HasOne("MidTermNetCore.Models.Khoa", "KhoaNavigation")
                        .WithMany()
                        .HasForeignKey("MaKhoa");
                });
#pragma warning restore 612, 618
        }
    }
}