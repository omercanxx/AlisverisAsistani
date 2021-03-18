using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Product_Store
    {
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}
