using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.API.DTOs.ProductCommentDtos;
using BitirmeProjesi.API.DTOs.UserDtos;
using BitirmeProjesi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [Authorize]
        [HttpGet("favorite-products")]
        public async Task<IActionResult> GetMyFavoriteProducts()
        {
            return Ok(_mapper.Map<IEnumerable<FavoriteProductDto>>(await _userService.GetMyFavoriteProducts()));
        }
        [Authorize]
        [HttpGet("commented-products")]
        public async Task<IActionResult> GetMyCommentedProducts()
        {
            var x = await _userService.GetMyCommentedProducts();
            return Ok(_mapper.Map<List<CommentedProductDto>>(await _userService.GetMyCommentedProducts()));
        }
        [Authorize]
        [HttpPost("favorite-products/{productId}")]
        public async Task<IActionResult> AddFavoriteProduct(Guid productId)
        {
            await _userService.AddFavoriteProducts(productId);
            return Ok(productId);
        }
    }
}