using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
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

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, UpdateStatisticDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var statistic = _context.Statistics.FirstOrDefault(s => s.Id == id);

            statistic.QualityWork = updateDto.QualityWork;
            statistic.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            statistic.EffectivCommunication = updateDto.EffectivCommunication;
            statistic.HardSkils = updateDto.HardSkils;
            statistic.SoftSkils = updateDto.SoftSkils;
            statistic.LevelResponibility = updateDto.LevelResponibility;
            statistic.IdUser = updateDto.IdUser;

            _context.SaveChanges();

            return Ok(statistic.ToStatisticDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var statistic = _context.Statistics.FirstOrDefault(s=>s.Id == id);

            if(statistic == null)
                return NotFound();

            _context.Statistics.Remove(statistic);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
