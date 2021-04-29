using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Repository
{
    public class Product_ImageRepository : CustomRepository<Product_Image>, IProduct_ImageRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public Product_ImageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
