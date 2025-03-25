using BisnesManager.Database;
using BisnesManager.Database.Models;
using BisnesManager.ETL.Interfaces;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.Services;
using BisnesManager.WebAPI.Diplom.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenServices _tokenServices;
        private readonly AuthRepository _authRepository;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        public AuthController(TokenServices tokenServices, 
            AuthRepository authRepository, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _tokenServices = tokenServices;
            _authRepository = authRepository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("Authorizate")]
        public async Task<ActionResult<string>> Authorizate([FromBody]AuthDataDto dataDto)
        {
            if (dataDto == null)
            {
                return BadRequest("Authorization data is not be null");
            }

            var user = await _authRepository.FindUser(dataDto);

            if (user == null) return Unauthorized("Invalid login!");


            if(_passwordHasher.VerifyHashedPassword(null, user.Password, dataDto.Password) 
                != PasswordVerificationResult.Failed )
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Login) };
                var jwt = new JwtSecurityToken(
                        issuer: AuthOptions.ISSUER,
                        audience: AuthOptions.AUDIENCE,
                        claims: claims,
                        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(20)), // время действия 2 минуты
                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                return new JwtSecurityTokenHandler().WriteToken(jwt);

              //  return Ok(_tokenServices.CreateToken(user));
            }
            else
            {
                return Unauthorized("Username not found and/or pasword is incorrect!");
            }

        }
    }
}
