using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Repositories
{
    public interface IUserRepository : ICustomRepository<ApplicationUser>
    {
        Task<List<Product>> GetMyFavoriteProducts(Guid userId);
        Task<Guid> GetUserIdByUsername(string username);
    }
}
