using BisnesManager.DatabasePersistens.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public PlansController(BissnesExpertSystemDiplomaContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = _context.HolidayPlans.ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var data = _context.HolidayPlans.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }
    }
}
