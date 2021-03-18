using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class UserService : CustomService<ApplicationUser>, IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitOfWork, ICustomRepository<ApplicationUser> repository, IHttpContextAccessor httpContextAccessor ) : base(unitOfWork, repository)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApplicationUser> GetUserWithFavoriteProducts()
        {
            return await _unitOfWork.Users.GetUserWithFavoriteProducts(_httpContextAccessor.HttpContext.User?.Identity?.Name);
        }
    }
}
