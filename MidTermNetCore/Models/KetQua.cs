using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int MaSV { get; set; }
        [ForeignKey("MaSV")]
        public virtual SinhVien SinhVienNavigation { get; set; }
        public int MaLHP { get; set; }
        [ForeignKey("MaLHP")]
        public virtual LopHocPhan LopHocPhanNavigation { get; set; }
    }
}
