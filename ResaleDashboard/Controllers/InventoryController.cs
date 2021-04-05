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
        public ActionResult Index()
        {
            return View(_db.Inventories.ToList());
        }
    }
}