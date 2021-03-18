using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Repository
{
    public class CategoryRepository : CustomRepository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Category> GetWithProductsByIdAsync(Guid categoryId)
        {
            return await _appDbContext.Categories.Include(c => c.ProductTypes).ThenInclude(pt => pt.Products).SingleOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<Category> GetWithProductTypesByIdAsync(Guid categoryId)
        {
            return await _appDbContext.Categories.Include(c => c.ProductTypes).SingleOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}
