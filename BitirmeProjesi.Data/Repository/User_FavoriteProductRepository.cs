using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Data.Repository
{
    public class User_FavoriteProductRepository : CustomRepository<ApplicationUser_FavoriteProduct>, IUser_FavoriteProductRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public User_FavoriteProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
