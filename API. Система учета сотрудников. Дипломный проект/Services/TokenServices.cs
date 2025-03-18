using BisnesManager.Database.Models;
using BisnesManager.ETL.Interfaces;
using BisnesManager.WebAPI.Diplom.Auth;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace BisnesManager.ETL.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenServices(IConfiguration conf)
        {
            _config = conf;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }

        public string CreateToken(User user)
        {
            var _claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Login),
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            
            var jwt = new JwtSecurityToken(
               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: _claims,
               expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(120)),
               signingCredentials: new SigningCredentials(
                    _key, 
                    SecurityAlgorithms.HmacSha256)
               );
           
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(_claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
