using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs
{
    public class ProductCommentSaveDto
    {
        public Guid ProductId { get; set; }
        public string Comment { get; set; }
        public bool IsAnonym { get; set; }
    }
}
