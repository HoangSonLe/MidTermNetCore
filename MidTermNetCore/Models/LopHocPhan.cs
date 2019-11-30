using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class LopHocPhan
    {
        [Key]
        [Required]
        public int MaLHP { get; set; }
        [Required]
        public int NamHoc { get; set; }
        [Required]
        public int HocKy { get; set; }
        public double DiemGK { get; set; }
        public double DiemCK { get; set; }
        public int? MaSV { get; set; }
        [ForeignKey("MaSV")]
        public virtual SinhVien SinhVienNavigation { get; set; }
        public int? Mon { get; set; }
        [ForeignKey("MaMonHoc")]
        public virtual MonHoc MonHocNavigation { get; set; }
    }
}
