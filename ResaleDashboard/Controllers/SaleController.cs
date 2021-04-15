using ResaleDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ResaleDashboard.Controllers
{
    public class SaleController : Controller
    {
        private SaleDbContext _db = new SaleDbContext();
        //[Route("Sale/Index")]
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            return View(_db.Sales.ToList());
        }  
        //[Route("Sale/Create")]
        [HttpGet]
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
    }
}