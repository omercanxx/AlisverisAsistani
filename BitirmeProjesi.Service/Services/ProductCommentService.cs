using BitirmeProjesi.API.Exceptions;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class ProductCommentService : CustomService<ProductComment>, IProductCommentService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        public ProductCommentService(IUnitOfWork unitOfWork, ICustomRepository<ProductComment> repository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<ProductComment>> GetWithUserByIdAsync(Guid productId)
        {
            return await _unitOfWork.ProductComments.GetWithUserByIdAsync(productId);
        }

        public async Task<Guid> RemoveProductComment(Guid productCommentId)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");

            var dbProductComment = await _unitOfWork.ProductComments.SingleOrDefaultAsync(x => x.Id == productCommentId);
            if (dbProductComment.UserId != user.Id)
                throw new CustomException("Yorumu silemezsiniz");

            _unitOfWork.ProductComments.Deactivate(dbProductComment);

            await _unitOfWork.CommitAsync();
            return user.Id;
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
