using BitirmeProjesi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly Guid[] _categoryIds;
        public CategorySeed(Guid[] categoryIds)
        {
            _categoryIds = categoryIds;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _categoryIds[0], Name = "Gömlek", IsActive = true},
                new Category { Id = _categoryIds[1], Name = "Pantolon", IsActive = true},
                new Category { Id = _categoryIds[2], Name = "Şapka", IsActive = true},
                new Category { Id = _categoryIds[3], Name = "Kazak", IsActive = true}
                );
        }
    }
}
