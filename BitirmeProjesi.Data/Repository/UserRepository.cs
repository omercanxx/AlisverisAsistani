using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Data.Repository
{
    public class UserRepository : CustomRepository<ApplicationUser>, IUserRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<ApplicationUser> GetUserWithFavoriteProducts(string username)
        {
            return await _appDbContext.Users
                .Include(u => u.User_FavoriteProduct)
                .ThenInclude(ufP => ufP.Product)
                .SingleOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<Guid> GetUserIdByUsername(string username)
        {
            var dbUser = await _appDbContext.Users.SingleOrDefaultAsync(u => u.UserName == username);
            return dbUser.Id;
        }
    }
}