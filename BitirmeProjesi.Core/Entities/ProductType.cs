using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class ProductType
    {
        public ProductType()
        {
            IsActive = true;
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
