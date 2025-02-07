using BisnesManager.DatabasePersistens.Context;
using BisnesManager.ETL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private BissnesExpertSystemDiplomaContext context;

        public StatusesController(BissnesExpertSystemDiplomaContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = context.Statuses.ToList().Select(s=>s.ToStatusDTO());
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] short id)
        {
            var data = context.Statuses.Find(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatusDTO());
        }
    }
}
