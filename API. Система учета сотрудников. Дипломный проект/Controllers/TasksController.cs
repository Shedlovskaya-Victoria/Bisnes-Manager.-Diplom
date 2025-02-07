using BisnesManager.DatabasePersistens.Context;
using BisnesManager.ETL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public TasksController(BissnesExpertSystemDiplomaContext context)
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
    }
}
