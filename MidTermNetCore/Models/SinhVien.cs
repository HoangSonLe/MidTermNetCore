using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class SinhVien
    {
        [Key]
        [Required]
        public int MaSV { get; set; }
        [StringLength(50)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        [StringLength(11)]
        public string DienThoai { get; set; }
        public int? MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa KhoaNavigation { get; set; }
    }
}
