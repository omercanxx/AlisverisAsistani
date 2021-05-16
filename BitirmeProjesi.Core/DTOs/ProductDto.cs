using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int Color { get; set; }
        public string Barcode { get; set; }
        public string ProductNo { get; set; }
    }
}
