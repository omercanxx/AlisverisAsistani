using BitirmeProjesi.Core.DTOs.FavoriteProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.DTOs.UserDtos
{
    public class FavoriteProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FavoriteProductImageDto ProductImage { get; set; }
    }
}
