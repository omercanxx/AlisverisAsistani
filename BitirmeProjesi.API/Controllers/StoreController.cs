using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.Core.DTOs;
using BitirmeProjesi.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BitirmeProjesi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }
        [HttpGet("map")]
        public async Task<IActionResult> GetStoresWithProductModel(MapPostDto request)
        {
            return Ok(_mapper.Map<List<MapDto>>(await _storeService.GetStoresWithProductsAsync(request.ProductNo, request.Color, request.Size)));
        }
        [HttpGet("color")]
        public async Task<IActionResult> GetColorsWithSize(ColorPostDto request)
        {
            return Ok(_mapper.Map<List<ColorDto>>(await _storeService.GetColorsWithSize(request.StoreId, request.ProductNo, request.Size)));
        }
        [HttpGet("size")]
        public async Task<IActionResult> GetSizesWithColor(SizePostDto request)
        {
            return Ok(await _storeService.GetSizesWithColor(request.StoreId, request.ProductNo, request.Color));
        }
    }
}
