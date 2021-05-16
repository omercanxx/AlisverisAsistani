using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.ProductCommentDtos
{
    public class CommentedProductImageDto
    {
        public Guid Id { get; set; }
        public int Sort { get; set; }
        public string Path { get; set; }
    }
}
