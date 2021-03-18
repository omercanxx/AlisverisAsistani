using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Configurations
{
    public class User_FavoriteProductConfiguration : IEntityTypeConfiguration<ApplicationUser_FavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser_FavoriteProduct> builder)
        {
            builder.HasKey(uf => new { uf.ProductId, uf.UserId });
            builder.HasOne<Product>(uf => uf.Product)
                .WithMany(p => p.User_FavoriteProduct)
                .HasForeignKey(uf => uf.ProductId);
            builder.HasOne<ApplicationUser>(uf => uf.User)
                .WithMany(u => u.User_FavoriteProduct)
                .HasForeignKey(uf => uf.UserId);

            builder.ToTable("User_FavoriteProducts");
        }
    }
}
