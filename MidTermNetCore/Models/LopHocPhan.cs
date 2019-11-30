using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual MonHoc MonHocNavigation { get; set; }
        public virtual ICollection<KetQua> KetQuas { get; set; }
    }
}
