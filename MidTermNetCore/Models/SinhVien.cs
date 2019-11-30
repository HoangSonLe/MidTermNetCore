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
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public virtual string MaKhoaNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
