﻿using ResaleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    public class PlatformController : Controller
    {
        private PlatformDbContext _db = new PlatformDbContext();
        // GET: Platform
        public ActionResult Index()
        {
            return View(_db.Platforms.ToList());
        }
        // Get: Platform/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}