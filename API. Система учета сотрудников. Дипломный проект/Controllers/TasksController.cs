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
    public class TasksController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public TasksController(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.BisnesTasks.Include(s => s.IdUserNavigation).Include(s => s.IdStatusNavigation).ToListAsync();
            var listDto = list.Select(s=>s.ToTaskDTO());

            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] short id)
        {
            var data = await _context.BisnesTasks.Include(s => s.IdUserNavigation).Include(s => s.IdStatusNavigation).FirstOrDefaultAsync(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToTaskDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskDtoRequest dtoRequest)
        {
            var taskModel = dtoRequest.ToTaskFromCreateDTO();
            await _context.BisnesTasks.AddAsync(taskModel);
            await _context.SaveChangesAsync();

            var returnValue = await _context.BisnesTasks
                .Include(s => s.IdStatusNavigation)
                .Include(s => s.IdUserNavigation)
                .FirstOrDefaultAsync(s => s.Id == taskModel.Id);
            return CreatedAtAction(nameof(Get), new { taskModel.Id }, returnValue.ToTaskDTO() );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdateTaskDto updateDto)
        {
            if(updateDto == null)
                return NotFound();
            var task = await _context.BisnesTasks.Include(s=>s.IdStatusNavigation).Include(s=>s.IdUserNavigation).FirstOrDefaultAsync(s => s.Id == id);

            task.StartDate = DateOnly.FromDateTime(updateDto.StartDate);
            task.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            task.IdUser = updateDto.IdUser;
            task.EndDate = DateOnly.FromDateTime(updateDto.EndDate);
            task.Indentation = updateDto.Indentation;
            task.AssignmentsContent = updateDto.AssignmentsContent;
            task.IdStatus = updateDto.IdStatus;
            task.Content = updateDto.Content;
           

            await _context.SaveChangesAsync();
            return Ok(task.ToTaskDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var task = await _context.BisnesTasks.FirstOrDefaultAsync(s=>s.Id == id);

            if(task == null)
                return NotFound();

            _context.BisnesTasks.Remove(task);
           await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
