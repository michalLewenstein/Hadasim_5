using Grocery.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Grocer> Grocers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Supplier → Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Supplier)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            // Supplier → Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order → ProductOrder
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany() 
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.NoAction); 

        }
    }
}
