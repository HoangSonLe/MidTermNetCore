using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class KetQua
    {
        [Key]
        [Required]
        public int MaKetQua { get; set; }
        public double DiemGK { get; set; }
        public double DiemCK { get; set; }
        public virtual SinhVien SinhVienNavigation { get; set; }
        public virtual LopHocPhan LopHocPhanNavigation { get; set; }
    }
}
