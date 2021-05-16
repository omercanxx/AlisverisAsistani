using BitirmeProjesi.API.Exceptions;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class UserService : CustomService<ApplicationUser>, IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitOfWork, ICustomRepository<ApplicationUser> repository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Guid> AddFavoriteProduct(Guid productId)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");

            ApplicationUser_FavoriteProduct favoriteProduct = new ApplicationUser_FavoriteProduct()
            {
                ProductId = productId,
                UserId = user.Id
            };
            await _unitOfWork.User_FavoriteProducts.AddAsync(favoriteProduct);

            await _unitOfWork.CommitAsync();
            return user.Id;
        }

        public async Task<List<Product>> GetMyCommentedProducts()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");
            return await _unitOfWork.ProductComments.GetMyCommentedProducts(user.Id);
        }
        public async Task<List<Product>> GetMyScannedProducts()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");
            return await _unitOfWork.Scans.GetProductsByUserIdAsync(user.Id);
        }

        public async Task<List<Product>> GetMyFavoriteProducts()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name); 
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");
            return await _unitOfWork.Users.GetMyFavoriteProducts(user.Id);
        }

        public async Task<Guid> RemoveFavoriteProduct(Guid productId)
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");

            var dbFavoriteProductList = await _unitOfWork.User_FavoriteProducts.GetAllAsync();
            var dbFavoriteProduct = dbFavoriteProductList.Where(f => f.UserId == user.Id && f.ProductId == productId).SingleOrDefault();

            if(dbFavoriteProduct == null)
                throw new CustomException("Kullanıcı bulunamadı");

            _unitOfWork.User_FavoriteProducts.Remove(dbFavoriteProduct);

            await _unitOfWork.CommitAsync();
            return user.Id;
        }

        public async Task<Guid> GetMyUserId()
        {
            var user = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (user == null)
                throw new CustomException("Kullanıcı bulunamadı");
            return user.Id;
        }
    }
}
