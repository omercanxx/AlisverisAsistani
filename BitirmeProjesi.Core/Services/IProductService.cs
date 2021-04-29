using BitirmeProjesi.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace BitirmeProjesi.Core.Services
{
    public interface IProductService : ICustomService<Product>
    {
        Task<Product> GetProductAsync(Guid productId);
        Task<Product> GetWithCategoriesByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId);
        Task<Product> GetWithSupplementsByIdAsync(Guid productId);
        Task<Product> GetWithCommentsByIdAsync(Guid productId);
        Task<Product> Save(Guid productTypeId, Guid storeId, IEnumerable<IFormFile> images, string name, int stock, int size, string barcode, string productNo, int color, decimal price);
    }
}
