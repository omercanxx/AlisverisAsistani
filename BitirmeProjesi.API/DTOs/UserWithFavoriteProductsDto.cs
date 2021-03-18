using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs
{
    public class UserWithFavoriteProductsDto
    {
        public string UserName { get; set; }
        public IEnumerable<User_FavoriteProductDto> User_FavoriteProduct { get; set; }
    }
}
