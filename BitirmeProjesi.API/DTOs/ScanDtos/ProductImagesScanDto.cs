using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs.ScanDtos
{
    public class ProductImagesScanDto
    {
        public Guid Id { get; set; }
        public int Sort { get; set; }
        public string Path { get; set; }
    }
}
