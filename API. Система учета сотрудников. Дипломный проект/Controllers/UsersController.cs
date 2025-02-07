using BisnesManager.DatabasePersistens.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var list = context.Users.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var data = context.Roles.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
