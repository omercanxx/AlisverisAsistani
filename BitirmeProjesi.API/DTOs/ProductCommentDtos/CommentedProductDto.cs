using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs.ProductCommentDtos
{
    public class CommentedProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CommentedProductImageDto> ProductImages { get; set; }
    }
}
