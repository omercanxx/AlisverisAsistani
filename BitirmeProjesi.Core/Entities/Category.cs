using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Category
    {
        public Category()
        {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
