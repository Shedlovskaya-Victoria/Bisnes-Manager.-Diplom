using BisnesManager.DatabasePersistens.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BisnesManager.ETL.Mapper;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public RolesController(BissnesExpertSystemDiplomaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _context.Roles.ToList().Select(s=>s.ToRoleDTO());

            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role.ToRoleDTO());
        }
    }
}
