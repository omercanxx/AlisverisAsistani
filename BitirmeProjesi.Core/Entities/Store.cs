using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Store
    {
        public Store()
        {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<Product_Store> Product_Store { get; set; }
    }
}
