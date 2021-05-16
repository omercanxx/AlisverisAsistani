using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.ScanDtos
{
    public class ProductCommentScanDto
    {
        public Guid ProductId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
        [JsonIgnore]
        public bool IsAnonym { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
