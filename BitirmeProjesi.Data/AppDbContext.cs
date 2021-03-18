using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Data.Configurations;
using BitirmeProjesi.Data.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, UserRoles, Guid>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base
        (options)
        {
        }
        public DbSet<ApplicationUser_FavoriteProduct> User_FavoriteProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Store> Product_Stores { get; set; }
        public DbSet<ProductRate> ProductRates { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Store> Stores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Entity Type Configuration
            modelBuilder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new Product_StoreConfiguration());
            modelBuilder.ApplyConfiguration(new User_FavoriteProductConfiguration());
            #endregion

            #region Seed
            modelBuilder.ApplyConfiguration(new ProductSeed(new Guid[] { new Guid("cf31a586-6e0e-435c-bd2c-cdd984df1468"), new Guid("32a0c082-e77b-4b9e-a876-e45a22f039b5")}));
            modelBuilder.ApplyConfiguration(new CategorySeed(new Guid[] { new Guid("f6d8a67d-0ec4-48c0-91a3-b7a523550150"), new Guid("a3800423-5c68-4564-a278-e6aa5e0493e5"), new Guid("e040998b-b168-4d47-9ac4-67b1037aa779"), new Guid("6708aa90-f527-4233-b4b1-c2aeb3e22234") }));
            modelBuilder.ApplyConfiguration(new ProductTypeSeed(new Guid[] { new Guid("cf31a586-6e0e-435c-bd2c-cdd984df1468"), new Guid("32a0c082-e77b-4b9e-a876-e45a22f039b5") }, new Guid("f6d8a67d-0ec4-48c0-91a3-b7a523550150")));

            #endregion

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
