using BisnesManager.Database;
using BisnesManager.Database.Models;
using BisnesManager.ETL.Interfaces;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.Services;
using BisnesManager.WebAPI.Diplom.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _authRepository.FindUser(dataDto);

            if (user == null) return Unauthorized("Invalid login!");


            if(_passwordHasher.VerifyHashedPassword(null, user.Password, dataDto.Password) 
                != PasswordVerificationResult.Failed )
            {
                return Ok(_tokenServices.CreateToken(user));
            }
            else
            {
                return Unauthorized("Username not found and/or pasword is incorrect!");
            }

        }
    }
}
