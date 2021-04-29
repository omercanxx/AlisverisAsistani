using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.API.DTOs;
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
        public async Task<IActionResult> WhoAmI()
        {
            return Ok(_mapper.Map<UserWithFavoriteProductsDto>(await _userService.GetUserWithFavoriteProducts()));
        }
    }
}