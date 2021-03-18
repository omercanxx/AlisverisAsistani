using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.Entities
{
    public class ProductComment
    {
        public ProductComment()
        {
            IsActive = true;
        }
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string Comment { get; set; }
        public int CommentStatu { get; set; }
        public bool IsAnonym { get; set; }
        public bool IsActive { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
