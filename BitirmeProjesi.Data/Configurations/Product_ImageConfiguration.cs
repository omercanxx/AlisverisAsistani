using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Configurations
{
    public class Product_ImageConfiguration : IEntityTypeConfiguration<Product_Image>
    {
        public void Configure(EntityTypeBuilder<Product_Image> builder)
        {
            builder.HasKey(pi => new { pi.ProductId, pi.ImageId });
            builder.HasOne<Product>(pi => pi.Product)
                .WithMany(p => p.Product_Image)
                .HasForeignKey(pi => pi.ProductId);
            builder.HasOne<Image>(pi => pi.Image)
                .WithMany(s => s.Product_Image)
                .HasForeignKey(pi => pi.ImageId);

            builder.ToTable("Product_Images");
        }
    }
}
