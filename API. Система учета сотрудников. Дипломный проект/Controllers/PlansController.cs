
using BisnesManager.Database.Models;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.Repositories;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly PlanRepository _planRepo;
        public PlansController(PlanRepository planRepo)
        {
            _planRepo = planRepo;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            
            var list = await _planRepo.GetAllAsync();
            if (list == null) return NotFound();
            var listDto = list.Select(s=>s.ToPlanDTO());

            return Ok(listDto);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _planRepo.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToPlanDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlanDtoRequest dtoRequest)
        {
            var roleModel = dtoRequest.ToPlanFromCreateDTO();
            await _planRepo.CreateAsync(roleModel);

            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToPlanDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdatePlanDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var plan = await _planRepo.UpdateAsync(id, updateDto);       
           if(plan == null) return NotFound();
            return Ok(plan.ToPlanDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async  Task<IActionResult> Delete([FromRoute] int id)
        {
            var plan = await _planRepo.DeleteAsync(id);

            if(plan == null) return NotFound();

            return NoContent();
        }
    }
}
