using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<ProductComment> GetWithProductByIdAsync(Guid productCommentId)
        {
            return await _appDbContext.ProductComments.Include(pc => pc.Product).SingleOrDefaultAsync(pc => pc.Id == productCommentId);
        }
    }
}
