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
        public async Task<Product> GetProductAsync(Guid productId)
        {
            return await appDbContext.Products
                .Include(p => p.ProductType).ThenInclude(pt => pt.Category)
                .Include(p => p.ProductComments)
                .Include(p => p.Product_Image).ThenInclude(p => p.Image)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }
        public async Task<Product> GetProductAsync(string productNo, int color, int size)
        {
            var dbProducts = await appDbContext.Products
                .Include(p => p.Product_Store)
                .ThenInclude(ps => ps.Store)
                .Where(p => p.ProductNo == productNo).ToListAsync();

            return dbProducts.SingleOrDefault(x => x.Color == color && x.Size == size);
        }
        public async Task<Product> GetWithCategoriesByIdAsync(Guid productId)
        {
            return await appDbContext.Products
                .Include(p => p.ProductType)
                .ThenInclude(pt => pt.Category)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }
        public async Task<Product> GetProductByBarcodeAsync(string barcode)
        {
            return await appDbContext.Products
                .SingleOrDefaultAsync(x => x.Barcode == barcode);
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
                .SingleOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<Product> GetWithSupplementsByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetWithCommentsByIdAsync(Guid productId)
        {
            return await appDbContext.Products
                .Include(p => p.ProductComments)
                .SingleOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<IEnumerable<Store>> GetStoresWithBarcode(string barcode)
        {
            var product = await appDbContext.Products
                .Include(s => s.Product_Store)
                .ThenInclude(ps => ps.Store)
                .Where(p => p.Barcode == barcode).FirstOrDefaultAsync();


            var stores = product.Product_Store.Select(ps => ps.Store).ToList();
            return stores;
        }
        public async Task<List<Product>> GetMyCommentedProducts(Guid userId)
        {
            var dbProducts = await appDbContext.Products
                .Include(pc => pc.ProductComments)
                .Include(p => p.Product_Image)
                .ThenInclude(pi => pi.Image)
                .Where(x => x.IsActive == true && x.ProductComments.Any(x => x.IsActive == true && x.UserId == userId)).ToListAsync();


            return dbProducts;
        }
    }
}
