using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(9,2)");
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.ProductNo).IsRequired();
            builder.Property(x => x.Barcode).IsRequired();
            builder.ToTable("Products");
        }
    }
}