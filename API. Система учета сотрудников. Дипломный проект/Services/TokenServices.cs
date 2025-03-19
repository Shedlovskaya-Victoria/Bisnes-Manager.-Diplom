using BisnesManager.Database.Models;
using BisnesManager.ETL.Interfaces;
using BisnesManager.WebAPI.Diplom.Auth;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        public TokenServices(IConfiguration conf)
        {
            _config = conf;
        }

        public string CreateToken(User user)
        {
            var _claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim("ID", user.Id.ToString(), ClaimValueTypes.Integer32)
            };
            var creds = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"])),
                SecurityAlgorithms.HmacSha256);

            var jwt = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(
               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: _claims,
               expires: DateTime.Now.AddMinutes(120),
               signingCredentials: creds);
           
            return new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
