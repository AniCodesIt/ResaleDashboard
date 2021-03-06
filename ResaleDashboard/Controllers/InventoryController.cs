using ResaleDashboard.Models;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ResaleDashboard.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : Controller
    {
        private InventoryDbContext _db = new InventoryDbContext();
        // GET: Inventory
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View(_db.Inventories.ToList());
        }
        // Get: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _db.Inventories.Add(inventory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }
        // Get: Inventory/Delete/{id}
        public ActionResult Delete (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = _db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // Post: Inventory/Delete{id}
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Inventory inventory = _db.Inventories.Find(id);
            _db.Inventories.Remove(inventory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get: Inventory/Edit{id}
        public ActionResult Edit(int? id)
        {
    if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            Inventory inventory = _db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
        //POST: Inventory/Edit{id}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(inventory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }
        // Get: Inventory/Details{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Inventory inventory = _db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }
    }
}
