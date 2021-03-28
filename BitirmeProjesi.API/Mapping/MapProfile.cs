using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitirmeProjesi.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Categories
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();
            #endregion

            #region Products
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            #endregion


            #region ProductComment
            CreateMap<ProductComment, ProductCommentSaveDto>();
            CreateMap<ProductCommentSaveDto, ProductComment>();
            #endregion

            #region Users
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<ApplicationUser_FavoriteProduct, User_FavoriteProductDto>();
            CreateMap<User_FavoriteProductDto, ApplicationUser_FavoriteProduct>();

            CreateMap<ApplicationUser, UserWithFavoriteProductsDto>();
            CreateMap<UserWithFavoriteProductsDto, ApplicationUser>();

            #endregion
        }
    }
}
