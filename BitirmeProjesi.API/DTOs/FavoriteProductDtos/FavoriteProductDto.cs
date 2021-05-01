using BitirmeProjesi.API.DTOs.FavoriteProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.DTOs.UserDtos
{
    public class FavoriteProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<FavoriteProductImageDto> ProductImages { get; set; }
    }
}
