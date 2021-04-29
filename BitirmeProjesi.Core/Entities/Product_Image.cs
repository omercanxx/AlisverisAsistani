using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Product_Image
    {
        public Guid ProductId { get; set; }
        public Guid ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual Product Product { get; set; }
    }
}
