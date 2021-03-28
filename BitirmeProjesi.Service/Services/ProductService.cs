using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class ProductService : CustomService<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, ICustomRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoriesByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithCategoriesByIdAsync(productId);
        }

        public async Task<Product> GetWithCommentsByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithCommentsByIdAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetWithStoresByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithStoresByIdAsync(productId);
        }

        public async Task<Product> GetWithSupplementsByIdAsync(Guid productId)
        {
            return await _unitOfWork.Products.GetWithSupplementsByIdAsync(productId);
        }

        
    }
}
