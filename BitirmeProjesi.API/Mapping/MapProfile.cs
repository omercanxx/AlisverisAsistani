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
            CreateMap<ProductSaveDto, ProductComment>();
            #endregion

            #region ProductComment
            CreateMap<ProductCommentSaveDto, ProductComment>();
            CreateMap<ProductComment, ProductCommentDto>()
                .ForMember(opt => opt.Username, dest => dest
                .MapFrom(pc => (pc.IsAnonym== true) ? pc.User.UserName.Substring(0,2).PadRight(pc.User.UserName.Length, '*') : pc.User.UserName));
            #endregion

            #region Users
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<ApplicationUser, RegisterDto>();
            CreateMap<UserDto, ApplicationUser>();

            CreateMap<ApplicationUser_FavoriteProduct, User_FavoriteProductDto>();
            CreateMap<User_FavoriteProductDto, ApplicationUser_FavoriteProduct>();

            CreateMap<ApplicationUser, UserWithFavoriteProductsDto>();
            CreateMap<UserWithFavoriteProductsDto, ApplicationUser>();

            #endregion
        }
    }
}
