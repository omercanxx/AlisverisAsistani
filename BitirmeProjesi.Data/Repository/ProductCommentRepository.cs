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
    public class ProductCommentRepository : CustomRepository<ProductComment>, IProductCommentRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ProductCommentRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<ProductComment>> GetWithUserByIdAsync(Guid productId)
        {
            return await _appDbContext.ProductComments.Include(pc => pc.User).Where(pc => pc.ProductId == productId).ToListAsync();

        }
    }
}
