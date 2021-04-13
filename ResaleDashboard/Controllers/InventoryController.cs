using ResaleDashboard.Models;
using System;
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
    }
}
