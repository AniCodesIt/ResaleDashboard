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
        [HttpGet]
        //[ValidateAntiForgeryToken]
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
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Details{Platform/id}
        public ActionResult SalesbyPlatform(int? platformID)
        {
            if (platformID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var query =
                _db
                .Sales
                .Where(
                    e => e.PlatformID == platformID
                    )
                .Select(e =>
                    new Sale
                    {
                        SaleID = e.SaleID,
                        PlatformID = e.PlatformID,
                        InvID = e.InvID,
                        SaleDate = e.SaleDate,
                        SalePrice = e.SalePrice,
                        Profit = e.Profit
                    }
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());               
          
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Details{Category/id}
        //TODO: add ienumerable to inventory.category model
        public ActionResult SalesbyCategory(string categoryID)
        {
            var InvDb = new InventoryDbContext();
            if (categoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var query = _db.Sales.Join(InvDb.Inventories, s => s.InvID, i => i.InvID, (s, i) => new { Sales = s, Inventories = i })
                .Where(w => w.Inventories.Category == categoryID)
                .Select(e =>
                    new Sale
                    {
                        SaleID = e.Sales.SaleID,
                        PlatformID = e.Sales.PlatformID,
                        InvID = e.Sales.InvID,
                        SaleDate = e.Sales.SaleDate,
                        SalePrice = e.Sales.SalePrice,
                        Profit = e.Sales.Profit,                       
                    }                   
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Index{Brand/id}
        //TODO: add ienumerable to inventory.category model
        public ActionResult SalesbyBrand(string brandID)
        {
            var InvDb = new InventoryDbContext();
            if (brandID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var query = _db.Sales.Join(InvDb.Inventories, s => s.InvID, i => i.InvID, (s, i) => new { Sales = s, Inventories = i })
                .Where(w => w.Inventories.Brand == brandID)
                .Select(e =>
                    new Sale
                    {
                        SaleID = e.Sales.SaleID,
                        PlatformID = e.Sales.PlatformID,
                        InvID = e.Sales.InvID,
                        SaleDate = e.Sales.SaleDate,
                        SalePrice = e.Sales.SalePrice,
                        Profit = e.Sales.Profit
                    }
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Index{Platform/id}
        public ActionResult MTDSalesbyPlatform(int? platformID)
        {
            DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (platformID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var query =
                _db
                .Sales
                .Where(
                    e => e.PlatformID == platformID && e.SaleDate >= dtFrom                
                    )
                .Select(e =>
                    new Sale
                    {
                        SaleID = e.SaleID,
                        PlatformID = e.PlatformID,
                        InvID = e.InvID,
                        SaleDate = e.SaleDate,
                        SalePrice = e.SalePrice,
                        Profit = e.Profit
                    }
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Index{Brand/id}
        public ActionResult MTDSalesbyBrand(string brandID)
        {
            var InvDb = new InventoryDbContext();
            DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (brandID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var query = _db.Sales.Join(InvDb.Inventories, s => s.InvID, i => i.InvID, (s, i) => new { Sales = s, Inventories = i })
             .Where(w => w.Inventories.Brand == brandID)
             .Select(e =>
                    new Sale
                    {
                        SaleID = e.Sales.SaleID,
                        PlatformID = e.Sales.PlatformID,
                        InvID = e.Sales.InvID,
                        SaleDate = e.Sales.SaleDate,
                        SalePrice = e.Sales.SalePrice,
                        Profit = e.Sales.Profit
                    }
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        // Get: Sale/Index{Brand/id}
        public ActionResult MTDSalesbyCategory(string categoryID)
        {
            var InvDb = new InventoryDbContext();
            DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            if (categoryID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            var query = _db.Sales.Join(InvDb.Inventories, s => s.InvID, i => i.InvID, (s, i) => new { Sales = s, Inventories = i })
             .Where(w => w.Inventories.Category == categoryID)
             .Select(e =>
                    new Sale
                    {
                        SaleID = e.Sales.SaleID,
                        PlatformID = e.Sales.PlatformID,
                        InvID = e.Sales.InvID,
                        SaleDate = e.Sales.SaleDate,
                        SalePrice = e.Sales.SalePrice,
                        Profit = e.Sales.Profit
                    }
                    );
            if (query == null)
            {
                return HttpNotFound();
            }
            return View(query.ToList());
        }
    }
}