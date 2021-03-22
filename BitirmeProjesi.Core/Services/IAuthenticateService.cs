using BitirmeProjesi.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BitirmeProjesi.Core.Services
{
    public interface IAuthenticateService
    {
        Task<JwtSecurityToken> Login(string username, string password);
        Task<ApplicationUser> Register(string email, string username, string password);
        Task<Guid> ChangePassword(string currentPassword, string newPassword);
        Task<ApplicationUser> WhoAmI();

    }
}
