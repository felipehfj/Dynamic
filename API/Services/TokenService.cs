using Domain.Models.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public static class TokenService
    {
        public static string GenerateToken(UserTokenModel user, IConfiguration Configuration)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = Configuration["Jwt:Secret"];
            var key = Encoding.ASCII.GetBytes(secret);

            ClaimsIdentity identity = new ClaimsIdentity(                      
                       new[] {
                            new Claim(ClaimTypes.Name, (user.Name).ToString()),
                            new Claim(ClaimTypes.Email, (user.Email).ToString()),
                            new Claim(ClaimTypes.GivenName, (user.ExibitionName ?? "").ToString()),
                            new Claim("id", (user.Id).ToString()),                           
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                       }
                   );


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Audience= user.Audience,
                Expires = DateTime.UtcNow.AddSeconds(double.Parse(Configuration["Jwt:Duration"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
