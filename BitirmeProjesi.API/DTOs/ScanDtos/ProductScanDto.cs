using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs.ScanDtos
{
    public class ProductScanDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Color { get; set; }
        public int Size { get; set; }
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
        public int LikesNumber { get; set; }
        public List<ProductImagesScanDto> ProductImages { get; set; }
        public List<ProductCommentScanDto> ProductComments { get; set; }
    }
}
