using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class SanPham
    {
        [Key]
        public int SanPhamID { get; set; }
        [Required]
        public string TenSanPham { get; set; }
        [Required]
        public decimal GiaSanPham { get; set; }
        [Required]
        public int DanhMucID { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}