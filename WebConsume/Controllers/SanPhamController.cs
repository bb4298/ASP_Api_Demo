using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DTO;
namespace WebConsume.Controllers
{
    public class SanPhamController : Controller
    {
        HttpClient client = new HttpClient();
        public SanPhamController()
        {
            
            client.BaseAddress = new Uri("http://localhost:52131/api/");
        }
        
        // GET: SanPham
        public ActionResult Index()
        {
            IEnumerable<SanPhamDTO> spDTO = null;
     
            var rpTask = client.GetAsync("SanPham");
            rpTask.Wait();
            var result = rpTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SanPhamDTO>>();
                readTask.Wait();
                spDTO = readTask.Result;
            }
            //else
            //{
            //    spDTO = Enumerable.Empty<SanPhamDTO>();
            //    ModelState.AddModelError(string.Empty, "server error");
            //}
            
            return View(spDTO);
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int id)
        {
            SanPhamDTO spDTO = null;    

            var rpTask = client.GetAsync("SanPham?id=" + id.ToString());
            var rpTask2 = client.GetAsync("DanhMuc");
            rpTask.Wait();
            var spResult = rpTask.Result;
            rpTask2.Wait();
            var dmResult = rpTask2.Result;
            if (spResult.IsSuccessStatusCode && dmResult.IsSuccessStatusCode)
            {
                var readTask = spResult.Content.ReadAsAsync<SanPhamDTO>();
                readTask.Wait();
                spDTO = readTask.Result;
                var readTask2 = dmResult.Content.ReadAsAsync<IList<string>>();
                readTask2.Wait();
                ViewBag.TenDanhMuc = new SelectList(readTask2.Result.ToList<string>(), spDTO.TenDanhMuc);
            }
            else ModelState.AddModelError(string.Empty, "Server error");
            
            return View(spDTO);
        }

        // GET: SanPham/Create
        ////[HttpGet]
        public ActionResult Create()
        {           
            var rpTask = client.GetAsync("DanhMuc");
            rpTask.Wait();
            var result = rpTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<string>>();
                readTask.Wait();
                ViewBag.TenDanhMuc = new SelectList(readTask.Result);
            }        
            
            return View();
        }

        // POST: SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPhamDTO spDTO)
        {         
            var postTask = client.PostAsJsonAsync<SanPhamDTO>("SanPham", spDTO);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            
            ModelState.AddModelError(string.Empty, "Server error");
            return View(spDTO);
        }

        // GET: SanPham/Edit/5
       
        public ActionResult Edit(int id)
        {
            SanPhamDTO spDTO = null;      

            var rpTask = client.GetAsync("SanPham?id=" + id.ToString());
            var rpTask2 = client.GetAsync("DanhMuc");
            rpTask.Wait();
            var spResult = rpTask.Result;
            rpTask2.Wait();
            var dmResult = rpTask2.Result;
            if (spResult.IsSuccessStatusCode && dmResult.IsSuccessStatusCode)
            {
                var readTask = spResult.Content.ReadAsAsync<SanPhamDTO>();
                readTask.Wait();
                spDTO = readTask.Result;
                var readTask2 = dmResult.Content.ReadAsAsync<IList<string>>();
                readTask2.Wait();
                ViewBag.TenDanhMuc = new SelectList(readTask2.Result.ToList<string>(), spDTO.TenDanhMuc);
            }
            else ModelState.AddModelError(string.Empty,"Server error");
            
            return View(spDTO);
        }

        // POST: SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPhamDTO spDTO)
        {          
            var putTask = client.PutAsJsonAsync<SanPhamDTO>("SanPham",spDTO);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View(spDTO);
        }

        // GET: SanPham/Delete/5
       
        
        public ActionResult Delete(int id)
        {       
            var deleteTask = client.DeleteAsync("SanPham?id=" +id.ToString());
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
                return RedirectToAction("Index");
            
            return RedirectToAction("Index");
        }

        //timkiem
        public ActionResult TimKiem(string Name)
        {
            IEnumerable<SanPhamDTO> spDTO = null;

            var rpTask = client.GetAsync("SanPham?Name="+Name.ToString());
            rpTask.Wait();
            var result = rpTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<SanPhamDTO>>();
                readTask.Wait();
                spDTO = readTask.Result;
            }
            else
            {
                spDTO = Enumerable.Empty<SanPhamDTO>();
                ModelState.AddModelError(string.Empty, "server error");
            }
            
            return View("Index",spDTO);
        }
        
       
    }
}
