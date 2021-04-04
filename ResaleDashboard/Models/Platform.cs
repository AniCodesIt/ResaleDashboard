using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResaleDashboard.Models
{
    public class Platform
    {
        public int PlatformID { get; set; }
        public string PlatformName { get; set; }
        public decimal Fees { get; set; }
    }
    public class PlatformDbContext : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
    }
}