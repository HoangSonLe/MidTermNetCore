using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class MonHoc
    {
        [Key]
        [Required]
        public int MaMon { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Tên phải nhiều hơn 2 kí tự")]
        public string TenMon { get; set; }
        [Required]
        public int SoTinChi { get; set; }
        public int MaKhoa { get; set; }
        [ForeignKey("MaKhoa")]
        public virtual Khoa KhoaNavigation { get; set; }
        public virtual ICollection<LopHocPhan> LopHocPhans { get; set; }
    }
}
