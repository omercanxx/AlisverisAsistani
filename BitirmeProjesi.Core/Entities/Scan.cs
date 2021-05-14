using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class Scan
    {
        public Scan()
        {
            CreatedOn = DateTime.Now;
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid StoreId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
