using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebService.Models
{
    public class DanhMuc
    {
        [Key]
        public int DanhMucID { get; set; }
        [Required]
        public string TenDanhMuc { get; set; }
        [Required]
        public virtual ICollection<SanPham> SanPhams { get; set; }

        public DanhMuc()
        {
            this.SanPhams = new List<SanPham>();
        }
    }
}