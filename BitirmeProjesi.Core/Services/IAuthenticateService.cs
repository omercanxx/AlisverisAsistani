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
        Task<JwtSecurityToken> Register(string email, string username, string password);
        Task<JwtSecurityToken> RegisterAdmin(string email, string username, string password);
        Task<Guid> ChangePassword(string currentPassword, string newPassword);
        Task<ApplicationUser> WhoAmI();

    }
}
