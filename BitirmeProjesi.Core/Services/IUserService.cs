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
        Task<ApplicationUser> GetUserWithFavoriteProducts();
    }
}
