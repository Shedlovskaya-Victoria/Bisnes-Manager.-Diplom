using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var list = _context.HolidayPlans.ToList().Select(s=>s.ToPlanDTO());

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var data = _context.HolidayPlans.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToPlanDTO());
        }
        [HttpPost]
        public IActionResult Create([FromBody] PlanDtoRequest dtoRequest)
        {
            var roleModel = dtoRequest.ToPlanFromCreateDTO();
            _context.HolidayPlans.Add(roleModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { roleModel.Id }, roleModel.ToPlanDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,  [FromBody] UpdatePlanDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var plan = _context.HolidayPlans.FirstOrDefault(s => s.Id == id);
            plan.StartWeekends = DateOnly.FromDateTime(updateDto.StartWeekends);
            plan.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            plan.EndWeekends = DateOnly.FromDateTime(updateDto.EndWeekends);
            plan.IdUser = updateDto.IdUser;
           

            _context.SaveChanges();
            return Ok(plan.ToPlanDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var plan = _context.HolidayPlans.FirstOrDefault(s=>s.Id == id);

            if(plan == null) return NotFound();

            _context.HolidayPlans.Remove(plan);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
