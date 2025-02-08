using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
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
    }
}
