using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Product
    {
        public Product()
        {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public virtual ProductType ProductType { get; set; }
        public ICollection<Product_Store> Product_Store { get; set; }
        public ICollection<ApplicationUser_FavoriteProduct> User_FavoriteProduct { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<ProductRate> ProductRates { get; set; }
    }
}
