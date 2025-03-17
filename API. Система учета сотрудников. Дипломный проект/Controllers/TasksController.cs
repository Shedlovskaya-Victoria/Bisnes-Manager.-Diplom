using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.Repositories;
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
        private readonly TaskRepository _taskRepo;

        public TasksController(BissnesExpertSystemDiploma7Context context, TaskRepository taskRepo)
        {
            _context = context;
            _taskRepo = taskRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterDateQueryDto query)
        {
            var list = await _taskRepo.GetAllAsync(query);
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToTaskDTO());

            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
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
            if (dtoRequest == null)
                return NotFound();

            var taskModel = dtoRequest.ToTaskFromCreateDTO();
            await _taskRepo.CreateAsync(taskModel);

            var returnValue = await _context.BisnesTasks
                .Include(s => s.IdStatusNavigation)
                .Include(s => s.IdUserNavigation)
                .FirstOrDefaultAsync(s => s.Id == taskModel.Id);
            if (returnValue == null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { taskModel.Id }, taskModel.ToTaskDTO() );
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdateTaskDto updateDto)
        {
            if(updateDto == null)
                return NotFound();
            var task = await _taskRepo.UpdateAsync(id, updateDto);         
            if(task == null) return NotFound();
            return Ok(task.ToTaskDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var task = await _taskRepo.DeleteAsync(id);

            if(task == null)
                return NotFound();

            return NoContent();
        }
    }
}
