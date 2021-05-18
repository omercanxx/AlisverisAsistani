using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.DTOs.ProductCommentDtos
{
    public class ProductCommentSummaryDto
    {
        public string Comment { get; set; }
        public bool IsAnonym { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
