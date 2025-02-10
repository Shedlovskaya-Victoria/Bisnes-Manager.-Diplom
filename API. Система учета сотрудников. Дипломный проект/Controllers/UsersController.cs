using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private BissnesExpertSystemDiploma7Context context;

        public UsersController(BissnesExpertSystemDiploma7Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll()
        {
            var list = await context.Users.Include(s => s.IdRoleNavigation).ToListAsync();
            var listDto = list.Select(s=>s.ToUserDTO());
            return Ok(listDto);
        }
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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDtoRequest dtoRequest)
        {
            var userModel = dtoRequest.ToUserFromCreateDTO();
           await context.Users.AddAsync(userModel);
           await context.SaveChangesAsync();
            var returnValue = await context.Users
                .Include(s => s.IdRoleNavigation)
                .FirstOrDefaultAsync(s => s.Id == userModel.Id);
            return CreatedAtAction(nameof(GetById), new { userModel.Id }, returnValue.ToUserDTO() );
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var user = await context.Users.Include(s=>s.IdRoleNavigation).FirstOrDefaultAsync(s => s.Id == id);

            user.Login = updateDto.Login;
            user.Password = updateDto.Password;
            user.Email = updateDto.Email;
            user.CheckPhrase = updateDto.CheckPhrase;
            user.IdRole = updateDto.IdRole;
            user.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            user.EndWorkTime = DateOnly.FromDateTime(updateDto.EndWorkTime);
            user.Family = updateDto.Family;
            user.Name = updateDto.Name;
            user.Patronymic = updateDto.Patronymic;
            user.PhotoImage = updateDto.PhotoImage;
            user.StartWorkTime = DateOnly.FromDateTime(updateDto.StartWorkTime);

            await context.SaveChangesAsync();

            return Ok(user.ToUserDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(s => s.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
