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
        public int ID { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập mã học phần")]
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
        public int? MaMon { get; set; }
        [ForeignKey("MaMon")]
        public virtual MonHoc MonHocNavigation { get; set; }
    }
}
