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
    public class PlansController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public PlansController(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.HolidayPlans.ToListAsync();
            var listDto = list.Select(s=>s.ToPlanDTO());

            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _context.HolidayPlans.FindAsync(id);

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
            await _context.HolidayPlans.AddAsync(roleModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToPlanDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdatePlanDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var plan = await _context.HolidayPlans.FirstOrDefaultAsync(s => s.Id == id);
            plan.StartWeekends = DateOnly.FromDateTime(updateDto.StartWeekends);
            plan.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            plan.EndWeekends = DateOnly.FromDateTime(updateDto.EndWeekends);
            plan.IdUser = updateDto.IdUser;
           

            await _context.SaveChangesAsync();
            return Ok(plan.ToPlanDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async  Task<IActionResult> Delete([FromRoute] int id)
        {
            var plan = await _context.HolidayPlans.FirstOrDefaultAsync(s=>s.Id == id);

            if(plan == null) return NotFound();

            _context.HolidayPlans.Remove(plan);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
