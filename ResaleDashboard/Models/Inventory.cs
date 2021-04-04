using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResaleDashboard.Models
{
    public class Inventory
    {
        [Key]
        public int InvID { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public decimal COG { get; set; }
        public int StockOnHand { get; set; }
        public string Location { get; set; }
    }
    public class InventoryDbContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; }

    }
}