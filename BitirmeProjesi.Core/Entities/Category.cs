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
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
