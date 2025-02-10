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
    public class StatusesController : ControllerBase
    {
        private BissnesExpertSystemDiploma7Context context;

        public StatusesController(BissnesExpertSystemDiploma7Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await context.Statuses.ToListAsync();
            var listDto = list.Select(s=>s.ToStatusDTO());
            return Ok(listDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] short id)
        {
            var data = await context.Statuses.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatusDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StatusDtoRequest dtoRequest)
        {
            var statusModel = dtoRequest.ToStatus();
            await context.Statuses.AddAsync(statusModel);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { statusModel.Id}, statusModel.ToStatusDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStatusDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

            var statusModel = await context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

            statusModel.Title = updateDto.Title;
            await context.SaveChangesAsync();

            return Ok(statusModel.ToStatusDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var status = await context.Statuses.FirstOrDefaultAsync(s=>s.Id == id);

            if(status == null)
                return NotFound();

            context.Statuses.Remove(status);

           await  context.SaveChangesAsync();

            return NoContent();
        }
    }
}
