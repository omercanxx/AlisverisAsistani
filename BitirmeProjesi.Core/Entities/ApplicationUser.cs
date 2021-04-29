using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class ApplicationUser : IdentityUser <Guid>
    {
        public ApplicationUser()
        {
            IsActive = true;
        }
        public ICollection<ApplicationUser_FavoriteProduct> User_FavoriteProduct { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<ProductRate> ProductRates { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
