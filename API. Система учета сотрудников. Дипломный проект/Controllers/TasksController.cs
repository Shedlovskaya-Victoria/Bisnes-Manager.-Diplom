using BisnesManager.DatabasePersistens.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            var list = _context.BisnesTasks.ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var data = _context.BisnesTasks.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
