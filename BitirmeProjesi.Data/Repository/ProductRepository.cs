using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Repository
{
    public class ProductRepository : CustomRepository<Product>, IProductRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Product> GetWithCategoriesByIdAsync(Guid productId)
        {
            return await appDbContext.Products
                .Include(p => p.ProductType)
                .ThenInclude(pt => pt.Category)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }
        public async Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId)
        {
            return await appDbContext.Products.Include(p => p.Product_Store).ThenInclude(pS => pS.Store).Where(p => p.Id == productId).ToListAsync();
        }

        public async Task<Product> GetWithProductTypesByIdAsync(Guid productId)
        {
            return await appDbContext.Products
                .Include(p => p.Product_Store)
                .ThenInclude(ps => ps.Store)
                .ThenInclude(s => s.User)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }

        public Task<Product> GetWithSupplementsByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
