using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class MyDBContext:DbContext
    {
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
        public DbSet<LopHocPhan> LopHocPhans { get; set; }
        public DbSet<MonHoc> MonHocs { get; set; }
        public MyDBContext(DbContextOptions<MyDBContext>
       options) : base(options)
        {
        }
    }
}
