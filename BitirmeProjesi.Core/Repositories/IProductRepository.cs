using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Repositories
{
    public interface IProductRepository : ICustomRepository<Product>
    {
        Task<Product> GetProductAsync(Guid productId);
        Task<Product> GetWithCategoriesByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId);
        Task<Product> GetWithCommentsByIdAsync(Guid productId);
        Task<Product> GetWithSupplementsByIdAsync(Guid productId);
        Task<Product> GetWithProductTypesByIdAsync(Guid productId);
        Task<Product> GetProductByBarcodeAsync(string barcode);
        Task<IEnumerable<Store>> GetStoresWithBarcode(string barcode);
        Task<List<Product>> GetMyCommentedProducts(Guid userId);
    }
}
