using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebService.Models;
namespace WebService.Models
{
    public class DataInit: CreateDatabaseIfNotExists<QLSPDB2>
    {
        protected override void Seed(QLSPDB2 context)
        {
            context.danhMucs.Add(new DanhMuc { TenDanhMuc = "Bánh" });
            context.danhMucs.Add(new DanhMuc { TenDanhMuc = "Kẹo" });
            context.danhMucs.Add(new DanhMuc { TenDanhMuc = "Trà Sữa" });
            context.SaveChanges();
            context.sanPhams.Add(new SanPham { TenSanPham = "Bánh kem", GiaSanPham = 20000, DanhMucID = 1 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Bánh cam", GiaSanPham = 20000, DanhMucID = 1 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Bánh dâu", GiaSanPham = 20000, DanhMucID = 1 });

            context.sanPhams.Add(new SanPham { TenSanPham = "Kẹo me", GiaSanPham = 20000, DanhMucID = 2 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Kẹo đậu", GiaSanPham = 20000, DanhMucID = 2 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Kẹo the", GiaSanPham = 20000, DanhMucID = 2 });

            context.sanPhams.Add(new SanPham { TenSanPham = "Trà sữa trân châu", GiaSanPham = 20000, DanhMucID = 3 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Trà sữa thái", GiaSanPham = 20000, DanhMucID = 3 });
            context.sanPhams.Add(new SanPham { TenSanPham = "Trà sữa đường đen", GiaSanPham = 20000, DanhMucID = 3 });


            base.Seed(context);
        }
    }
}