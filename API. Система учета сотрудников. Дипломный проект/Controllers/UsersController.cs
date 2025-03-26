
using BisnesManager.Database.Models;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BissnesExpertSystemDiploma7Context context;
        private readonly UserRepository _userRepo;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public UsersController(BissnesExpertSystemDiploma7Context context, UserRepository userRepo,
            UserManager<IdentityUser> userManager, IPasswordHasher<IdentityUser> passwordHasher)
        {
            this.context = context;
            _userRepo = userRepo;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public  async Task<IActionResult> GetAll([FromQuery] SortQueryDto query)
        {
            var list = await _userRepo.GetAllAsync(query);
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToUserDTO());
            return Ok(listDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
        {
            var data = await context.Users.Include(s => s.IdRoleNavigation).FirstOrDefaultAsync(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToUserDTO());
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDtoRequest dtoRequest)
        {
            if (dtoRequest == null)
                return NotFound();

            var passwordValidator = new PasswordValidator<IdentityUser>();
            var result = await passwordValidator.ValidateAsync(_userManager, null, dtoRequest.Password);

            if (result.Succeeded)
            {
                var userModel = dtoRequest.ToUserFromCreateDTO();
                var hasedPassword = _passwordHasher.HashPassword(new IdentityUser(), dtoRequest.Password);
                userModel.Password = hasedPassword;
               
                var user = await _userRepo.CreateAsync(userModel);
                if (user == null) return BadRequest("Пользователь с таким логином уже существует!");
                
               
                return CreatedAtAction(nameof(GetById), new { userModel.Id }, user.ToUserDTO());
            }
            else
            {
               return BadRequest(result);
            }

           
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var user = await _userRepo.UpdateAsync(id, updateDto);           

            if(user == null) return NotFound();

            return Ok(user.ToUserDTO());
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            var user = await _userRepo.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
