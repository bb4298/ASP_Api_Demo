using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DTO;
namespace WebConsume.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        public ActionResult Index()
        {
            IEnumerable<DanhMucDTO> dmDTO = null;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:52131/api/");
            var responseTask = client.GetAsync("DanhMuc");
            responseTask.Wait();
            var result = responseTask.Result;
            if(result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<DanhMucDTO>>();
                readTask.Wait();
                dmDTO = readTask.Result;
            }
            else
            {
                dmDTO = Enumerable.Empty<DanhMucDTO>();
                ModelState.AddModelError(string.Empty, "Server error");
            }
            return View(dmDTO);
        }

        // GET: DanhMuc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DanhMuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DanhMuc/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMuc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DanhMuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DanhMuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DanhMuc/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
