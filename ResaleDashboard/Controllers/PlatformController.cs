using ResaleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    [RoutePrefix("api/Platform")]
    public class PlatformController : Controller
    {
        private PlatformDbContext _db = new PlatformDbContext();
        // GET: Platform
        [HttpGet]
        public ActionResult Index()
        {
            return View(_db.Platforms.ToList());
        }
        // Get: Platform/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Platform platform)
        {
            if (ModelState.IsValid)
            {
                _db.Platforms.Add(platform);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platform);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = _db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // Post: Platform/Delete{id}
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Platform platform = _db.Platforms.Find(id);
            _db.Platforms.Remove(platform);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get: Platform/Edit{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Platform platform = _db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }
        //POST: Platform/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Platform platform)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(platform).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(platform);
        }
        // Get: Platform/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Platform platform = _db.Platforms.Find(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }
    }
}