using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using WebService.Models;

namespace WebService.Controllers
{
    public class SanPhamController : ApiController
    {
        QLSPDB2 db = new QLSPDB2();
        // GET: api/SanPham
        public IHttpActionResult GetAllSanPham()
        {
            IList<SanPhamDTO> spDTO = null;            
            spDTO = db.sanPhams.Include("DanhMuc")
                .Select(p => new SanPhamDTO()
                {
                    SanPhamID = p.SanPhamID,
                    TenSanPham = p.TenSanPham,
                    GiaSanPham = p.GiaSanPham,
                    TenDanhMuc = p.DanhMuc.TenDanhMuc
                }).ToList<SanPhamDTO>();
            
            if (spDTO.Count == 0)
                return NotFound();
            return Ok(spDTO);
        }
        // GET: api/SanPham/5
        public IHttpActionResult GetSanPhamByID(int id)
        {
            SanPhamDTO spDTO = null;

            spDTO = db.sanPhams.Include("DanhMuc")
                .Where(p => p.SanPhamID == id)
                .Select(p => new SanPhamDTO()
                {
                    SanPhamID = p.SanPhamID,
                    TenSanPham = p.TenSanPham,
                    GiaSanPham = p.GiaSanPham,
                    TenDanhMuc = p.DanhMuc.TenDanhMuc
                }).FirstOrDefault<SanPhamDTO>();
    
            if(spDTO == null)
            {
                return NotFound();
            }
            return Ok(spDTO);
        }

        public IHttpActionResult GetSanPhamByName(string Name)
        {
            IList<SanPhamDTO> spDTO = null;
 
            spDTO = db.sanPhams.Include("DanhMuc")
                .Where(p=>p.TenSanPham.Contains(Name))
                .Select(p => new SanPhamDTO()
                {
                    SanPhamID = p.SanPhamID,
                    TenSanPham = p.TenSanPham,
                    GiaSanPham = p.GiaSanPham,
                    TenDanhMuc = p.DanhMuc.TenDanhMuc
                }).ToList<SanPhamDTO>();
            
            if (spDTO.Count == 0)
                return NotFound();
            return Ok(spDTO);
        }

        // POST: api/SanPham
        public IHttpActionResult PostSanPham(SanPhamDTO spDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid data");
            
            SanPham sp = ChuyenDTOthanhSP(spDTO);
            if(sp != null)
            {
                db.sanPhams.Add(sp);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest("Invalid data");           
        }

        // PUT: api/SanPham/5
        public IHttpActionResult PutSanPham(SanPhamDTO spDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not is a valid model");
            
                var spCu = db.sanPhams
                    .Where(p => p.SanPhamID == spDTO.SanPhamID)
                    .FirstOrDefault<SanPham>();
                if(spCu != null)
                {
                    if(CapNhatSanPham(spCu,spDTO))
                    {
                        db.SaveChanges();
                        return Ok();
                    }
                    return BadRequest("not a valid model");
                }
                return NotFound();                            
        }

        // DELETE: api/SanPham/5
        public IHttpActionResult DeleteSanPham(int id)
        {
            if (id < 0)
                return BadRequest("ID ko hợp lệ");
                var sp = db.sanPhams
                    .Where(p => p.SanPhamID == id)
                    .FirstOrDefault();
                db.Entry(sp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();      
            return Ok();
        }


        //Internal method

        private DanhMuc LayDanhMucByTen(string tenDanhMuc)
        {
            DanhMuc dm = null;
            dm = db.danhMucs
                .Where(c => c.TenDanhMuc.ToLower() == tenDanhMuc.ToLower())
                .FirstOrDefault();
            return dm;
        }

        private bool CapNhatSanPham(SanPham sp, SanPhamDTO spDTO)
        {
            DanhMuc dm = LayDanhMucByTen(spDTO.TenDanhMuc);
            if(dm != null)
            {
                sp.TenSanPham = spDTO.TenSanPham;
                sp.GiaSanPham = spDTO.GiaSanPham;
                sp.DanhMucID = dm.DanhMucID;
                return true;
            }
            return false;
        }

        private SanPham ChuyenDTOthanhSP(SanPhamDTO spDTO)
        {
            DanhMuc dm = LayDanhMucByTen(spDTO.TenDanhMuc);
            if(dm != null)
            {
                SanPham sp = new SanPham();
                sp.TenSanPham = spDTO.TenSanPham;
                sp.GiaSanPham = spDTO.GiaSanPham;
                sp.DanhMucID = dm.DanhMucID;
                return sp;
            }
            return null;
        }

        
    }
}
