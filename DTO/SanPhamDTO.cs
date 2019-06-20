using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        [Required]
        [Display(Name = "Tên Sản Phẩm")]
        public int SanPhamID { get; set; }
        [Required]
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSanPham { get; set; }
        [Required]
        [Display(Name = "Giá Sản Phẩm")]
        public decimal GiaSanPham { get; set; }
        [Required]
        [Display(Name = "Tên Danh Mục")]
        public string TenDanhMuc { get; set; }
    }
}
