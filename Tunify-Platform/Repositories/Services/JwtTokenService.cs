using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using NuGet.Packaging;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tunify_Platform.Models;

namespace Tunify_Platform.Repositories.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public JwtTokenService(IConfiguration config, SignInManager<ApplicationUser> signInManager)
        {
            _config = config;
            _signInManager = signInManager;
        }

        public static TokenValidationParameters ValidateToken(IConfiguration config)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(config),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            return tokenValidationParameters;
        }
        private static SecurityKey GetSecurityKey(IConfiguration config)
        {
            var secret = config["JWT:SecertKey"];
            if (secret == null) {
                throw new Exception("JWT:SecertKey not found");
            }
            var secertBytes = Encoding.UTF8.GetBytes(secret);
            return new SymmetricSecurityKey(secertBytes);
        }
        public async Task<string> GenerateToken(ApplicationUser user, TimeSpan expireyDate, IList<string> roles)
        {
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);

            if(userPrincipal == null)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.AddRange(userPrincipal.Claims);
            var signInKey = GetSecurityKey(_config);
            var token = new JwtSecurityToken(
                expires: DateTime.Now.Add(expireyDate),
                signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
