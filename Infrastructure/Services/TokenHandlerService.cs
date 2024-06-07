using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TokenHandlerService(IConfiguration configuration) : ITokenHandlerService
    {
        private readonly IConfiguration _configuration = configuration;

        public TokenDto CreateAccessToken(int minute, Admin admin)
        {
            TokenDto tokenDto = new();
            tokenDto.Expiration = DateTime.UtcNow.AddMinutes(minute);

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]!));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);

            JwtSecurityToken securityToken = new
                (
                    audience: _configuration["Token:Audience"],
                    issuer: _configuration["Token:Issuer"],
                    expires: tokenDto.Expiration,
                    notBefore: DateTime.UtcNow,
                    signingCredentials: signingCredentials,
                    claims: new List<Claim> { new(ClaimTypes.NameIdentifier, admin.Id) }
                );
            JwtSecurityTokenHandler tokenHandler = new();
            tokenDto.AccessToken = tokenHandler.WriteToken(securityToken);
            return tokenDto;
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
