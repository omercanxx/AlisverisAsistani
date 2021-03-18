using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Configurations
{
    public class Product_StoreConfiguration : IEntityTypeConfiguration<Product_Store>
    {
        public void Configure(EntityTypeBuilder<Product_Store> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.StoreId });
            builder.HasOne<Product>(ps => ps.Product)
                .WithMany(p => p.Product_Store)
                .HasForeignKey(ps => ps.ProductId);
            builder.HasOne<Store>(ps => ps.Store)
                .WithMany(s => s.Product_Store)
                .HasForeignKey(ps => ps.StoreId);

            builder.ToTable("Product_Stores");
        }
    }
}