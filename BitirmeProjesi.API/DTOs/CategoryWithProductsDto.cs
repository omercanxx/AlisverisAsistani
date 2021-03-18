using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs
{
    public class CategoryWithProductsDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
