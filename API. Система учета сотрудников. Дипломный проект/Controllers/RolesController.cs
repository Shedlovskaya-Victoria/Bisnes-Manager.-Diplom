using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using BisnesManager.Database.Interfaces;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        private readonly IRoleRepository roleRepo;
        public RolesController(BissnesExpertSystemDiploma7Context context, IRoleRepository roleRepo)
        {
            _context = context;
            this.roleRepo = roleRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await roleRepo.GetAllAsync();
            var roleDto = roles.Select(s=>s.ToRoleDTO());

            return Ok(roleDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role.ToRoleDTO());
        }
        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] RoleDtoRequest dtoRequest)
        {
            var roleModel = dtoRequest.ToRoleFromCreateDTO();
            await _context.Roles.AddAsync(roleModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToRoleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async  Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRoleDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

            var role = await _context.Roles.FirstOrDefaultAsync(s=>s.Id == id);
            role.Title = updateDto.Title;
            role.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            role.IsEditWorkersRoles = updateDto.IsEditWorkersRoles;
            role.IsEditWorkTimeTable = updateDto.IsEditWorkTimeTable;
            role.Post = updateDto.Post;

            await _context.SaveChangesAsync();

            return Ok(role.ToRoleDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(s=> s.Id == id);

            if(role == null)
                return NotFound();

            _context.Roles.Remove(role);

           await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
