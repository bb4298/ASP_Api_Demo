using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class DanhMucDTO
    {
        [Required]
        [Display(Name ="Danh mục ID")]
        public int DanhMucID { get; set; }
        [Required]
        [Display(Name = "Tên Danh Mục")]
        public string TenDanhMuc { get; set; }
    }
}
