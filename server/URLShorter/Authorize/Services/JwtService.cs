using Authorize.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authorize.Services
{
    class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(IdentityUser user, IList<string> userRoles)
        {

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: CreateClaims(user, userRoles),
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: signIn);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        private Claim[] CreateClaims(IdentityUser user, IList<string> userRoles)
        {
            return new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("id", user.Id),
                        new Claim("name", user.UserName),
                        new Claim("email", user.Email),
                        new Claim("roles", string.Join(',', userRoles))
                    };
        }
    }
}
