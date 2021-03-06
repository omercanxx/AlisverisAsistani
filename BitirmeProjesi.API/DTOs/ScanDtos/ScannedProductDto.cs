using BitirmeProjesi.API.DTOs.ProductCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs.ScanDtos
{
    public class ScannedProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ScannedProductImageDto ProductImage { get; set; }
    }
}
