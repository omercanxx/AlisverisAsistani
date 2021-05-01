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
                .Include(p => p.Product_Store).ThenInclude(pt => pt.Product).ThenInclude(p => p.Product_Image).ThenInclude(pi => pi.Image)
                .Include(p => p.Product_Store).ThenInclude(pt => pt.Product).ThenInclude(p => p.ProductComments).ThenInclude(pc => pc.User)
                .Include(p => p.Product_Store).ThenInclude(pt => pt.Product).ThenInclude(p => p.User_FavoriteProduct)
                .SingleOrDefaultAsync(x => x.Id == storeId);
        }

        public async Task<Store> GetClosestStoreAsync(IEnumerable<Store> stores, double longtitude, double latitude)
        {
            var storesWithDistances = stores.Select(x => new {
                Id = x.Id,
                Longtitude = x.Longtitude,
                Latitude = x.Latitude,
                Distance = GetDistance(longtitude, latitude, x.Longtitude, x.Latitude)
            }).ToList();

            var closestStoreId = storesWithDistances.OrderBy(s => s.Distance).FirstOrDefault().Id;
            return await appDbContext.Stores.Where(s => s.Id == closestStoreId).SingleOrDefaultAsync();
        }

        private double GetDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
