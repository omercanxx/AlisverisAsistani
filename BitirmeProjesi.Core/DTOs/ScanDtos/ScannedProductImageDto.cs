using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.ScanDtos
{
    public class ScannedProductImageDto
    {
        public Guid Id { get; set; }
        public int Sort { get; set; }
        public string Path { get; set; }
    }
}
