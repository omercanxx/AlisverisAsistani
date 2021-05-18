using BitirmeProjesi.API.Exceptions;
using BitirmeProjesi.Core.Entities;
using BitirmeProjesi.Core.Repositories;
using BitirmeProjesi.Core.Services;
using BitirmeProjesi.Core.UnitOfWorks;
using BitirmeProjesi.Data.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Service.Services
{
    public class AuthenticateService : CustomService<ApplicationUser>, IAuthenticateService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<UserRoles> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthenticateService(UserManager<ApplicationUser> userManager, RoleManager<UserRoles> roleManager, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, ICustomRepository<ApplicationUser> repository) : base(unitOfWork, repository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<JwtSecurityToken> Login(string username, string password)
        {

            JwtSecurityToken token = null;
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || await _userManager.CheckPasswordAsync(user, password) == false)
                throw new DomainException("Kullanıcı adı veya şifre hatalı");
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<JwtSecurityToken> Register(string email, string username, string password)
        {
            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
                throw new CustomException($"Sistemde {username} isimli kullanıcı mevcut");


            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new CustomException($"Sistemde {username} isimli kullanıcı oluşturulamadı");

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<JwtSecurityToken> RegisterAdmin(string email, string username, string password)
        {
            var userExists = await _userManager.FindByNameAsync(username);
            if (userExists != null)
                throw new CustomException($"Sistemde {username} isimli admin mevcut");

            ApplicationUser user = new ApplicationUser()
            {
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new CustomException($"Sistemde {username} isimli kullanıcı oluşturulamadı");

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                UserRoles role = new UserRoles()
                {
                    Name = "Admin"
                };
                await _roleManager.CreateAsync(role);
            }
            
            if (await _roleManager.RoleExistsAsync("Admin"))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };


            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

        public async Task<Guid> ChangePassword(string currentPassword, string newPassword)
        {
            var dbUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);
            if (await _userManager.CheckPasswordAsync(dbUser, currentPassword) == false)
            {
                throw new CustomException("Güncel parola yanlış");
            }
            await _userManager.ChangePasswordAsync(dbUser, currentPassword, newPassword);

            return dbUser.Id;
        }


        public async Task<ApplicationUser> WhoAmI()
        {
            var dbUser = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User?.Identity?.Name);

            return dbUser;
        }
    }
}
