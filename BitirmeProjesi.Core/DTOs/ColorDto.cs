using BitirmeProjesi.Core.DTOs.ScanDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitirmeProjesi.Core.DTOs
{
    public class ColorDto
    {
        public int Color { get; set; }
        public List<ProductImagesScanDto> ProductImages { get; set; }
    }
}