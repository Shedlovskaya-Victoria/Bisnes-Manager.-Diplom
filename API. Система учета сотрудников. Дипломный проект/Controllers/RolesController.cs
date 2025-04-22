using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.Database.Models;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleRepository roleRepo;
        public RolesController(RoleRepository roleRepo)
        {
            this.roleRepo = roleRepo;
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await roleRepo.GetAllAsync();
            if (roles == null) return NotFound();
            var roleDto = roles.Select(s=>s.ToRoleUpdate());

            return Ok(roleDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetRolesFilterManager")]
        public async Task<IActionResult> GetRolesFilterManager()
        {
            var roles = await roleRepo.GetRolesFilterManagerAsync();
            if (roles == null) return NotFound();
            var roleDto = roles.Select(s=>s.ToRoleUpdate());

            return Ok(roleDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetAllFilterIsUse")]
        public async Task<IActionResult> GetAllFilterIsUse()
        {
            var roles = await roleRepo.GetAllFilterIsUseAsync();
            if (roles == null) return NotFound();
            var roleDto = roles.Select(s=>s.ToRoleUpdate());

            return Ok(roleDto);
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
        {
          
            var role = await roleRepo.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role.ToRoleDTO());
        }
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] RoleDtoRequest dtoRequest)
        {
            var roleModel = dtoRequest.ToRoleFromCreateDTO();
            await roleRepo.CreateAsync(roleModel);
            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToRoleDTO());
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        public async  Task<IActionResult> Update([FromBody] UpdateRoleDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

           var role = await roleRepo.UpdateAsync(updateDto.Id, updateDto);

            if (role == null)
                return NotFound();

            return Ok(role.ToRoleDTO());
        }
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            var role = await roleRepo.DeleteAsync(id);

            if(role == null)
                return NotFound();

            return NoContent();
        }
    }
}
