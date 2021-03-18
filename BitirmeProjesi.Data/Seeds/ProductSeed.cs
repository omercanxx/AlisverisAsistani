using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly Guid[] _productTypeIds;
        public ProductSeed(Guid[] productTypeIds)
        {
            _productTypeIds = productTypeIds;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = new Guid("38d68adc-8444-4c69-b57e-205fbc830bd6"), Name = "Klasik Gömlek", Price = 115m, Stock = 100, Color = 1, Size = 1,Barcode ="111111", ProductNo = "111", IsActive = true, ProductTypeId = _productTypeIds[0]},
                new Product { Id = new Guid("e06f36da-7a54-4848-9147-74f891360d05"), Name = "Klasik Gömlek", Price = 115m, Stock = 150, Color = 2, Size = 1, Barcode = "111112", ProductNo = "111", IsActive = true, ProductTypeId = _productTypeIds[0]},
                new Product { Id = new Guid("b198d9a3-faf4-4b32-9dc4-2bc19913b83c"), Name = "Spor Gömlek", Price = 50m, Stock = 180, Color = 1, Size = 1, Barcode = "222111", ProductNo = "222", IsActive = true, ProductTypeId = _productTypeIds[1]},
                new Product { Id = new Guid("e58a5840-e80c-475b-86bd-448a40f80c90"), Name = "Spor Gömlek", Price = 50m, Stock = 200, Color = 1, Size = 1, Barcode = "222112", ProductNo = "222", IsActive = true, ProductTypeId = _productTypeIds[1] }
                );
        }
    }
}

