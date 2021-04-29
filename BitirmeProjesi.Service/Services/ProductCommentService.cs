using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class ProductCommentService : CustomService<ProductComment>, IProductCommentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ProductCommentService(IUnitOfWork unitOfWork, ICustomRepository<ProductComment> repository, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ProductComment>> GetWithUserByIdAsync(Guid productId)
        {
            return await _unitOfWork.ProductComments.GetWithUserByIdAsync(productId);
        }

        public async Task<ProductComment> Save(Guid productId, string comment, bool isAnonym)
        {
            var userId = await _unitOfWork.Users.GetUserIdByUsername(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            ProductComment productComment = new ProductComment() {
                ProductId = productId,
                UserId = userId,
                Comment = comment,
                IsAnonym = isAnonym
            };
            await _unitOfWork.ProductComments.AddAsync(productComment);
            await _unitOfWork.CommitAsync();
            return productComment;
        }
    }
}
