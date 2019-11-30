using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual int MaKhoaNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
