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
    public class ScanRepository : CustomRepository<Scan>, IScanRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ScanRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<List<Product>> GetProductsByUserIdAsync(Guid userId)
        {
            var dbScans = _appDbContext.Scans
                .Include(s => s.Product)
                .ThenInclude(p => p.Product_Image)
                .ThenInclude(pi => pi.Image).Where(s => s.UserId == userId).ToList();
            return dbScans.Select(s => s.Product).ToList();
        }
    }
}
