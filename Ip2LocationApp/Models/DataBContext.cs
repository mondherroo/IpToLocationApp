using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ip2LocationApp.Models
{
    public class DataBContext : DbContext
    {
        public DataBContext(DbContextOptions<DataBContext> options) : base(options) { }

        
        public DbSet<ip2location_db11> Ip { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ip2location_db11>().ToTable("ip2location_db11");

        }
    }
}
