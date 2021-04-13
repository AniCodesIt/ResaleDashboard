using ResaleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    public class SaleController : Controller
    {
        private SaleDbContext _db = new SaleDbContext();
        // GET: Sale
        public ActionResult Index()
        {
            return View(_db.Sales.ToList());
        }
        // Get: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}