using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Repository
{
    public class Product_StoreRepository : CustomRepository<Product_Store>, IProduct_StoreRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public Product_StoreRepository(AppDbContext context) : base(context)
        {
        }
    }
}

