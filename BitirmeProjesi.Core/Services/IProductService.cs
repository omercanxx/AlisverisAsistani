using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IProductService : ICustomService<Product>
    {
        Task<Product> GetWithCategoriesByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId);
        Task<Product> GetWithSupplementsByIdAsync(Guid productId);
        Task<Product> GetWithCommentsByIdAsync(Guid productId);
    }
}
