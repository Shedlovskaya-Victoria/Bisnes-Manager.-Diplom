﻿using BisnesManager.Database;
using BisnesManager.Database.Models;
using BisnesManager.ETL.Auth;
using BisnesManager.ETL.Interfaces;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.request_DTO;
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
        private readonly AuthRepository _authRepository;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;
        public AuthController(AuthRepository authRepository, IPasswordHasher<IdentityUser> passwordHasher)
        {
            _authRepository = authRepository;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("Authorizate")]
        public async Task<IActionResult> Authorizate([FromBody]AuthDataDto dataDto)
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

                var authResponse = new AuthDtoRequest { Token = new JwtSecurityTokenHandler().WriteToken(jwt), User = user.ToUserDTO() };
                return Ok(authResponse);

              //  return Ok(_tokenServices.CreateToken(user));
            }
            else
            {
                return Unauthorized("Username not found and/or pasword is incorrect!");
            }

        }
    }
}
