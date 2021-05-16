using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs
{
    public class ScanDto
    {
        public string Barcode { get; set; }
        public float Longitude { get; set; } 
        public float Latitude { get; set; }
    }
}
