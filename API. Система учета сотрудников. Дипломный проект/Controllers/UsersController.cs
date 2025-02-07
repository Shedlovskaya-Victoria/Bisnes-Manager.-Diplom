using BisnesManager.DatabasePersistens.Context;
using BisnesManager.ETL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private BissnesExpertSystemDiplomaContext context;

        public UsersController(BissnesExpertSystemDiplomaContext context)
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
        public IActionResult Get([FromRoute] short id)
        {
            var data = context.Users.Include(s => s.IdRoleNavigation).First(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToUserDTO());
        }
    }
}
