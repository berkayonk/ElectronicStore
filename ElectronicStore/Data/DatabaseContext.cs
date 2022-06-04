using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicStore.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicStore.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // Constructer
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WarrantytoProduct>().HasKey(wp => new { wp.Id, wp.productID }); // Define relationship
            modelBuilder.Entity<WarrantytoProduct>().HasOne(p => p.product).WithMany(wp => wp.warrantytoProducts).HasForeignKey(p => p.productID); // Define relationship product
            modelBuilder.Entity<WarrantytoProduct>().HasOne(w => w.warranty).WithMany(wp => wp.warrantytoProducts).HasForeignKey(w => w.Id); // Define relationship warranty
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Warranty> warranties { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<WarrantytoProduct> warrantytoProducts { get; set; }
        public DbSet<Seller> sellers { get; set; }
        public DbSet<Producer> producers { get; set; }
    }
}
