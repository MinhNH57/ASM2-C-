using ASM2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ASM2.Controllers
{
    public class HocVienController : Controller
    {
        private readonly ASM2Dbcontext _db;
        public HocVienController(ASM2Dbcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var sv = _db.HocViens.ToList();

            var lopHocs = _db.HocViens.ToList();

            return View(sv);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HocVien sv)
        {
            _db.HocViens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index", "HocVien");
        }

        public IActionResult Edit(Guid id)
        {
            var up = _db.HocViens.Find(id);
            if (up == null)
            {
                return NotFound();
            }
            else
            {
                return View(up);
            }
        }

        [HttpPost]
        public IActionResult Edit(HocVien sinhv)
        {
            var existingHocVien = _db.HocViens.AsNoTracking().FirstOrDefault(hv => hv.ID == sinhv.ID);
            if (existingHocVien != null)
            {
                var jsonOld = JsonConvert.SerializeObject(existingHocVien);
                HttpContext.Session.SetString("StudentBackup", jsonOld);
            }

            var jsonNew = JsonConvert.SerializeObject(sinhv);
            HttpContext.Session.SetString("Student", jsonNew);

            _db.HocViens.Update(sinhv);
            _db.SaveChanges();

            return RedirectToAction("Index", "HocVien");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var d = _db.HocViens.Find(id);

            _db.HocViens.Remove(d);
            _db.SaveChanges();
            return RedirectToAction("Index", "HocVien");
        }

        public IActionResult Details(Guid id)
        {
            var d = _db.HocViens.Find(id);
            return View(d);
        }

        public IActionResult ReviewData()
        {
            var dataD = HttpContext.Session.GetString("Student");
            if (dataD != null)
            {
                var Studeleted = JsonConvert.DeserializeObject<HocVien>(dataD);
                return View("ReviewData", Studeleted);
            }
            else
            {
                return Content("Deo co");
            }
        }

        [HttpPost]
        public IActionResult RollBackData()
        {
            if (HttpContext.Session.Keys.Contains("StudentBackup"))
            {
                var jsondata = HttpContext.Session.GetString("StudentBackup");
                var data = JsonConvert.DeserializeObject<HocVien>(jsondata);

                _db.HocViens.Update(data); 
                _db.SaveChanges();

                HttpContext.Session.Remove("StudentBackup"); 

                return RedirectToAction("Index", "HocVien");
            }
            else
            {
                return Content("No backup data found.");
            }

        }
    }
}
