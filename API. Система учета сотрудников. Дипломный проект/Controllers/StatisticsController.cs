using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public StatisticsController(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }
        [HttpPost("GetAllFromUserId")]
        public IActionResult GetAll([FromBody] short UserId)
        {
            var list = _context.Statistics.Where(s => s.IdUser == UserId).ToList().Select(s => s.ToStatisticDTO()).ToList();
             
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetByDate([FromRoute] int id)
        {
            var data = _context.Statistics.Find(id);
             
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatisticDTO());
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] StatisticDtoRequest dtoRequest)
        {
            var statisticModelm = dtoRequest.ToStatisticFromCreateDTO();
            _context.Statistics.Add(statisticModelm);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetByDate), new { statisticModelm.DateCreate }, statisticModelm.ToStatisticDTO());
        }
    }
}
