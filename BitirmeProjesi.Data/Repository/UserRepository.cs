using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Guid> GetUserIdByUsername(string username)
        {
            var dbUser = await _appDbContext.Users.SingleOrDefaultAsync(u => u.UserName == username);
            return dbUser.Id;
        }
        public async Task<List<Product>> GetMyFavoriteProducts(Guid userId)
        {
            var dbUser =  await _appDbContext.Users
                .Include(u => u.User_FavoriteProduct)
                .ThenInclude(ufp => ufp.Product)
                .ThenInclude(p => p.Product_Image)
                .ThenInclude(pi => pi.Image)
                .Where(u => u.Id == userId).SingleOrDefaultAsync();

            var products = dbUser.User_FavoriteProduct.Select(ps => ps.Product).ToList();
            return products;
        }
        
    }
}