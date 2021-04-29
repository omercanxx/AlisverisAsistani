using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BitirmeProjesi.API.DTOs;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace BitirmeProjesi.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticateController(IAuthenticateService authenticateService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _authenticateService = authenticateService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            UserDto user = new UserDto();
            bool isAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                user = _mapper.Map<UserDto>(await _authenticateService.WhoAmI());
            }
            return Ok(user);
        }
        [Authorize]
        [HttpPost]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            await _authenticateService.ChangePassword(model.CurrentPassword, model.NewPassword);
            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var token = await _authenticateService.Login(model.Username, model.Password);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var token = await _authenticateService.Register(model.Email, model.Username, model.Password);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto model)
        {
            var token = await _authenticateService.RegisterAdmin(model.Email, model.Username, model.Password);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}