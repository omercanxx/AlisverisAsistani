using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.API.DTOs.FavoriteProductDtos;
using BitirmeProjesi.API.DTOs.ProductCommentDtos;
using BitirmeProjesi.API.DTOs.ScanDtos;
using BitirmeProjesi.API.DTOs.UserDtos;
using BitirmeProjesi.Core.Entities;
using Microsoft.AspNetCore.Http;
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
            #region Scan
            CreateMap<Store, StoreScanDto>()
                .ForMember(opt => opt.Products, dest => dest.MapFrom(x => x.Product_Store.Select(ps => ps.Product)));

            CreateMap<Product, ProductScanDto>()
                .ForMember(opt => opt.ProductComments, dest => dest.MapFrom(x => x.ProductComments))
                .ForMember(opt => opt.ProductImages, dest => dest.MapFrom(x => x.Product_Image.Select(pi => pi.Image)))
                .ForMember(opt => opt.LikeNumber, dest => dest.MapFrom(x => x.User_FavoriteProduct.Count))
                .ForMember(opt => opt.ScanNumber, dest => dest.MapFrom(x => x.Scans.Count));


            CreateMap<Image, ProductImagesScanDto>();
            CreateMap<ProductComment, ProductCommentScanDto>()
                .ForMember(opt => opt.Username, dest => dest
                .MapFrom(pc => (pc.IsAnonym == true) ? pc.User.UserName.Substring(0, 2).PadRight(pc.User.UserName.Length, '*') : pc.User.UserName));

            CreateMap<Product, ScannedProductDto>()
                .ForMember(opt => opt.ProductImage, dest => dest.MapFrom(x => x.Product_Image.Select(pi => pi.Image).OrderBy(i => i.Sort).FirstOrDefault()));
            CreateMap<Image, ScannedProductImageDto>();
            #endregion

            #region FavoriteProducts
            CreateMap<Product, FavoriteProductDto>()
                .ForMember(opt => opt.ProductImage, dest => dest.MapFrom(x => x.Product_Image.Select(pi => pi.Image).OrderBy(i => i.Sort).FirstOrDefault()));
            CreateMap<Image, FavoriteProductImageDto>();
            #endregion

            #region CommentedProucts
            CreateMap<Product, CommentedProductDto>()
                .ForMember(opt => opt.ProductImage, dest => dest.MapFrom(x => x.Product_Image.Select(pi => pi.Image).OrderBy(i => i.Sort).FirstOrDefault()));
            CreateMap<Image, CommentedProductImageDto>();
            #endregion

            #region Categories
            CreateMap<Category, CategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();
            #endregion

            #region Products
            CreateMap<Product, ProductDto>();
            CreateMap<ProductSaveDto, Product>();
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
