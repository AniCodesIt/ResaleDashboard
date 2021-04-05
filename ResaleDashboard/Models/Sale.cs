using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResaleDashboard.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        //add foreign key
        public int PlatformID { get; set; }
        //add foreign key
        public int InvID { get; set; }
        public DateTime SaleDate { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        public decimal Profit { get; set; }

    }
    public class SaleDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
    }
}