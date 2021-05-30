using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Core.DTOs;
using BitirmeProjesi.Core.DTOs.ProductCommentDtos;
using BitirmeProjesi.Core.DTOs.ScanDtos;
using BitirmeProjesi.Core.DTOs.UserDtos;
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
        private readonly IProductCommentService _productCommentService;
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IProductCommentService productCommentService, IStoreService storeService, IMapper mapper)
        {
            _userService = userService;
            _productCommentService = productCommentService;
            _mapper = mapper;
            _storeService = storeService;
        }
        #region Favorites
        [Authorize]
        [HttpPost("favorite/{productId}")]
        public async Task<IActionResult> AddFavoriteProduct(Guid productId)
        {
            await _userService.AddFavoriteProduct(productId);
            return Ok(productId);
        }
        [Authorize]
        [HttpDelete("favorite/{productId}")]
        public async Task<IActionResult> RemoveFavoriteProduct(Guid productId)
        {
            await _userService.RemoveFavoriteProduct(productId);
            return Ok(productId);
        }
        [Authorize]
        [HttpGet("favorite")]
        public async Task<IActionResult> GetMyFavoriteProducts()
        {
            return Ok(_mapper.Map<IEnumerable<FavoriteProductDto>>(await _userService.GetMyFavoriteProducts()));
        }
        #endregion

        #region Comments
        [Authorize]
        [HttpGet("comment")]
        public async Task<IActionResult> GetMyCommentedProducts()
        {
            return Ok(_mapper.Map<List<CommentedProductDto>>(await _userService.GetMyCommentedProducts()));
        }

        [Authorize]
        [HttpDelete("comment/{productCommentId}")]
        public async Task<IActionResult> RemoveProductComment(Guid productCommentId)
        {
            await _productCommentService.RemoveProductComment(productCommentId);
            return Ok(productCommentId);
        }
        #endregion

        #region Scans
        [HttpPost("scan")]
        public async Task<IActionResult> Scan(ScanDto scan)
        {

            return Ok(await _storeService.GetStoresWithBarcode(scan.Barcode, scan.Longitude, scan.Latitude));
        }

        [Authorize]
        [HttpGet("scan")]
        public async Task<IActionResult> GetMyScannedProducts()
        {
            return Ok(_mapper.Map<List<ScannedProductDto>>(await _userService.GetMyScannedProducts()));
        }

        #endregion
    }
}