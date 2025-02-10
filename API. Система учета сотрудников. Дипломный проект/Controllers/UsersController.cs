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
        public IActionResult GetAll()
        {
            var list = context.Users.Include(s=>s.IdRoleNavigation).ToList().Select(s=>s.ToUserDTO());
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] short id)
        {
            var data = context.Users.Include(s => s.IdRoleNavigation).First(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToUserDTO());
        }
        [HttpPost]
        public IActionResult Create([FromBody] UserDtoRequest dtoRequest)
        {
            var userModel = dtoRequest.ToUserFromCreateDTO();
            context.Users.Add(userModel);
            context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { userModel.Id }, context.Users
                .Include(s => s.IdRoleNavigation)
                .First(s => s.Id == userModel.Id)
                .ToUserDTO()
                );
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateUserDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var user = context.Users.Include(s=>s.IdRoleNavigation).FirstOrDefault(s => s.Id == id);

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

            context.SaveChanges();

            return Ok(user.ToUserDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var user = context.Users.FirstOrDefault(s => s.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            context.SaveChanges();
            return NoContent();
        }
    }
}
