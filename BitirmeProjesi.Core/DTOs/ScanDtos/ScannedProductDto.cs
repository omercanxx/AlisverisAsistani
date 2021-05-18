using BitirmeProjesi.Core.DTOs.ProductCommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.ScanDtos
{
    public class ScannedProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public ScannedProductImageDto ProductImage { get; set; }
    }
}
