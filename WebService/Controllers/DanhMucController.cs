using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using DTO;
using WebService.Models;

namespace WebService.Controllers
{
    public class DanhMucController : ApiController
    {
        QLSPDB2 db = new QLSPDB2();

        //public IHttpActionResult GetAllDanhMuc()
        //{
        //    IList<DanhMucDTO> dm = null;

        //    dm = db.danhMucs
        //    .Select(p => new DanhMucDTO
        //    {
        //        DanhMucID = p.DanhMucID,
        //        TenDanhMuc = p.TenDanhMuc
        //    }).ToList<DanhMucDTO>();

        //    if (dm.Count == 0)
        //        return NotFound();
        //    return Ok(dm);
        //}
        // GET: api/DanhMuc
        public IHttpActionResult GetAllTenDanhMuc()
        {
            IList<string> tenDanhMuc = null;

            tenDanhMuc = db.danhMucs
            .Select(p => p.TenDanhMuc).ToList<string>();

            ////if (tenDanhMuc.Count == 0)
            ////    return NotFound();
            return Ok(tenDanhMuc);
        }

        // GET: api/DanhMuc/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DanhMuc
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DanhMuc/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DanhMuc/5
        public void Delete(int id)
        {
        }
    }
}
