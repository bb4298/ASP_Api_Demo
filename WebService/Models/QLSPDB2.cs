using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebService.Models
{
    public class QLSPDB2: DbContext
    {
        public QLSPDB2(): base("name=QLSPDB2")
        {

        }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<DanhMuc> danhMucs { get; set; }
    }
}