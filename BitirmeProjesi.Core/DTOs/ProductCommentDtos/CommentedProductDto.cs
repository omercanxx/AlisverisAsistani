using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.ProductCommentDtos
{
    public class CommentedProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public CommentedProductImageDto ProductImage { get; set; }
        public List<ProductCommentSummaryDto> ProductComments { get; set; }
    }
}
