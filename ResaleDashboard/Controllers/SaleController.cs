﻿using ResaleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    [RoutePrefix("api/Sale")]
    public class SaleController : Controller
    {
        private SaleDbContext _db = new SaleDbContext();
        [Route("Index")]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View(_db.Sales.ToList());
        }
        [Route("Create")]
        [HttpGet]      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _db.Sales.Add(sale);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = _db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }
        // Post: Sale/Delete{id}
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Sale sale = _db.Sales.Find(id);
            _db.Sales.Remove(sale);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Get: Sale/Edit{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Sale sale = _db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }
        //POST: Sale/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(sale).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sale);
        }
        // Get: Sale/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Sale sale = _db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }
    }
}