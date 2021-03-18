using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Seeds
{
    public class ProductTypeSeed : IEntityTypeConfiguration<ProductType>
    {
        private readonly Guid[] _productTypeIds;
        private readonly Guid _categoryId;
        public ProductTypeSeed(Guid[] productTypeIds, Guid categoryId)
        {
            _productTypeIds = productTypeIds;
            _categoryId = categoryId;
        }
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.HasData(
                new ProductType { Id = _productTypeIds[0], CategoryId = _categoryId, Name = "Klasik", IsActive = true },
                new ProductType { Id = _productTypeIds[1], CategoryId = _categoryId, Name = "Spor", IsActive = true }
                );
        }
    }
}