using ResaleDashboard.Models;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryDbContext _db = new InventoryDbContext();
        // GET: Inventory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View(_db.Inventories.ToList());
        }
        // Get: Inventory/Create
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
    }
}
