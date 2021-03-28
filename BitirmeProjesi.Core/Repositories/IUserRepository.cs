using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Repositories
{
    public interface IUserRepository : ICustomRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetUserWithFavoriteProducts(string username);
        Task<Guid> GetUserIdByUsername(string username);
    }
}
