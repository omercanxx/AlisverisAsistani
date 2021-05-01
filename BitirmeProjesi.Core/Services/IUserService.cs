using BitirmeProjesi.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IUserService : ICustomService<ApplicationUser>
    {
        Task<List<Product>> GetMyFavoriteProducts();
        Task<List<Product>> GetMyCommentedProducts();
        Task<Guid> AddFavoriteProducts(Guid productId);
    }
}
