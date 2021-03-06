using BitirmeProjesi.API.DTOs.ScanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs
{
    public class StoreScanDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<ProductScanDto> Products { get; set; }
    }
}
