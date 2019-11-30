using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MidTermNetCore.Models
{
    public class Khoa
    {
        [Required]
        [Key]
        public int MaKhoa { get; set; }

        [Required(ErrorMessage ="Tên khoa không được để trống")]
        [MinLength(2,ErrorMessage ="Tên khoa phải nhiều hơn 2 kí tự")]
        public string TenKhoa { get; set; }
        public virtual ICollection<MonHoc> MonHocs { get; set; }
    }
}
