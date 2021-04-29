using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs
{
    public class ProductSaveDto
    {
        public Guid ProductTypeId { get; set; }
        public Guid StoreId { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Size { get; set; }
        public int Color { get; set; }
        public decimal Price { get; set; }
        
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
    }
}
