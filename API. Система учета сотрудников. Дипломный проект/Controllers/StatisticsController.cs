using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public StatisticsController(BissnesExpertSystemDiplomaContext context)
        {
            _context = context;
        }
        [HttpPost("GetAllFromUserId")]
        public IActionResult GetAll([FromBody] short UserId)
        {
            var list = _context.Statistics.Where(s => s.IdUser == UserId).ToList().Select(s => s.ToStatisticDTO()).ToList();
             
            return Ok(list);
        }

        [HttpPost("GetOneFromDate")]
        public IActionResult Get([FromBody] DateTime dateCreate)
        {
            var data = _context.Statistics.First(s=>s.DateCreate == DateOnly.FromDateTime( dateCreate));
             
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatisticDTO());
        }
    }
}
