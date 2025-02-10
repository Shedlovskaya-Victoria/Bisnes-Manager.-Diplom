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
        public IActionResult GetAll()
        {
            var list = _context.BisnesTasks.Include(s=>s.IdUserNavigation).Include(s=>s.IdStatusNavigation).ToList().Select(s=>s.ToTaskDTO());

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var data = _context.BisnesTasks.Include(s => s.IdUserNavigation).Include(s => s.IdStatusNavigation).First(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToTaskDTO());
        }
        [HttpPost]
        public IActionResult Create([FromBody] TaskDtoRequest dtoRequest)
        {
            var taskModel = dtoRequest.ToTaskFromCreateDTO();
            _context.BisnesTasks.Add(taskModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { taskModel.Id }, _context.BisnesTasks
                .Include(s=>s.IdStatusNavigation)
                .Include(s=>s.IdUserNavigation)
                .First(s=>s.Id == taskModel.Id)
                .ToTaskDTO() 
                );
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id,  [FromBody] UpdateTaskDto updateDto)
        {
            if(updateDto == null)
                return NotFound();
            var task = _context.BisnesTasks.Include(s=>s.IdStatusNavigation).Include(s=>s.IdUserNavigation).FirstOrDefault(s => s.Id == id);

            task.StartDate = DateOnly.FromDateTime(updateDto.StartDate);
            task.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            task.IdUser = updateDto.IdUser;
            task.EndDate = DateOnly.FromDateTime(updateDto.EndDate);
            task.Indentation = updateDto.Indentation;
            task.AssignmentsContent = updateDto.AssignmentsContent;
            task.IdStatus = updateDto.IdStatus;
            task.Content = updateDto.Content;
           

            _context.SaveChanges();
            return Ok(task.ToTaskDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var task = _context.BisnesTasks.FirstOrDefault(s=>s.Id == id);

            if(task == null)
                return NotFound();

            _context.BisnesTasks.Remove(task);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
