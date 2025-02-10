using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.update_DTO;

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
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateRoleDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

            var role = _context.Roles.FirstOrDefault(s=>s.Id == id);
            role.Title = updateDto.Title;
            role.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            role.IsEditWorkersRoles = updateDto.IsEditWorkersRoles;
            role.IsEditWorkTimeTable = updateDto.IsEditWorkTimeTable;
            role.Post = updateDto.Post;

            _context.SaveChanges();

            return Ok(role.ToRoleDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var role = _context.Roles.FirstOrDefault(s=> s.Id == id);

            if(role == null)
                return NotFound();

            _context.Roles.Remove(role);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
