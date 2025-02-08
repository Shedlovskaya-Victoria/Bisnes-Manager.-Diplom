using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
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
    }
}
