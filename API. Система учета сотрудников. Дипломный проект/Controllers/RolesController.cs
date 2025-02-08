using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.Database.Context;
using BisnesManager.Database.Model;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public RolesController(BissnesExpertSystemDiploma7Context context)
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
        public IActionResult GetById([FromRoute] short id)
        {
            var role = _context.Roles.Find(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role.ToRoleDTO());
        }
        [HttpPost]
        public IActionResult Create([FromBody] RoleDtoRequest dtoRequest)
        {
            var roleModel = dtoRequest.ToRoleFromCreateDTO();
            _context.Roles.Add(roleModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToRoleDTO());
        }

    }
}
