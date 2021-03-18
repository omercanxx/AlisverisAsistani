using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class ProductRate
    {
        public ProductRate()
        {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public int Rate { get; set; }
        public int RateStatu { get; set; }
        public bool IsAnonym { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
