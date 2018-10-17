using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Assignment4
{
    class Assignment4Context: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("host=localhost; db=northwind; uid=postgres; psw=casperkaos ");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Category>().ToTable("categories");
        //    modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
        //    modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
        //    modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

        //    modelBuilder.Entity<Product>().ToTable("products");
        //    modelBuilder.Entity<Product>().Property()
        //}
    }
}
