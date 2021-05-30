using BitirmeProjesi.Core.DTOs.ScanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs
{
    public class StoreScanDto
    {
        public StoreScanDto()
        {
            Sizes = new List<int>();
            Colors = new List<int>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ProductScanDto> Products { get; set; }
        public List<int> Sizes { get; set; }
        public List<int> Colors { get; set; }
    }
}
