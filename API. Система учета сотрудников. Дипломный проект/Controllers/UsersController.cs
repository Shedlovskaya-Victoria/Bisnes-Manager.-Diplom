
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
        [HttpPost("GetListUsersToUpdate")]
        public  async Task<IActionResult> GetListUsersToUpdate([FromBody] SortQueryDto query)
        {
            var list = await _userRepo.GetAllAsync(query);
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToUpdateDto());
            return Ok(listDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var list = await _userRepo.GetAllAsync();
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToUserDTO()); //отличие от другого get all users в dto простом и для списка обновления
            return Ok(listDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            var data = await context.Users.Include(s => s.IdRoleNavigation).FirstOrDefaultAsync(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToUpdateDto());
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
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            if (!string.IsNullOrEmpty(updateDto.Password))
            {
                var hasedPassword = _passwordHasher.HashPassword(new IdentityUser(), updateDto.Password);
                updateDto.Password = hasedPassword;
            }
            updateDto.DateCreate = DateTime.Now;
            var user = await _userRepo.UpdateAsync(updateDto.Id, updateDto);           

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
