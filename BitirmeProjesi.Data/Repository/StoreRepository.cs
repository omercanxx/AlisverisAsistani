using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Repository
{
    public class StoreRepository : CustomRepository<Store>, IStoreRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public StoreRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Store> GetWithProductsByIdAsync(Guid storeId)
        {
            return await appDbContext.Stores
                .Include(p => p.Product_Store).ThenInclude(pt => pt.Product)
                .SingleOrDefaultAsync(x => x.Id == storeId);
        }

        public async Task<Store> GetClosestStoreAsync(IEnumerable<Store> stores, double longtitude, double latitude)
        {
            var storesWithDistances = stores.Select(x => new {
                Id = x.Id,
                Longtitude = x.Longtitude,
                Latitude = x.Latitude,
                Distance = GetDistance(longtitude, latitude, x.Longtitude, x.Latitude)
            });

            return await appDbContext.Stores.Where(s => s.Id == storesWithDistances.OrderByDescending(s => s.Distance).FirstOrDefault().Id).FirstOrDefaultAsync();
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
