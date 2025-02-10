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
    public class StatisticsController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public StatisticsController(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }
        [HttpPost("GetAllFromUserId")]
        public async Task<IActionResult> GetAll([FromBody] short UserId)
        {
            var list = await _context.Statistics.Where(s => s.IdUser == UserId).ToListAsync();
            var listDto = list.Select(s => s.ToStatisticDTO());
             
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByDate([FromRoute] int id)
        {
            var data = await _context.Statistics.FindAsync(id);
             
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatisticDTO());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] StatisticDtoRequest dtoRequest)
        {
            var statisticModelm = dtoRequest.ToStatisticFromCreateDTO();
            await _context.Statistics.AddAsync(statisticModelm);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByDate), new { statisticModelm.DateCreate }, statisticModelm.ToStatisticDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStatisticDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var statistic = await _context.Statistics.FirstOrDefaultAsync(s => s.Id == id);

            statistic.QualityWork = updateDto.QualityWork;
            statistic.DateCreate = DateOnly.FromDateTime(updateDto.DateCreate);
            statistic.EffectivCommunication = updateDto.EffectivCommunication;
            statistic.HardSkils = updateDto.HardSkils;
            statistic.SoftSkils = updateDto.SoftSkils;
            statistic.LevelResponibility = updateDto.LevelResponibility;
            statistic.IdUser = updateDto.IdUser;

           await _context.SaveChangesAsync();

            return Ok(statistic.ToStatisticDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var statistic = await _context.Statistics.FirstOrDefaultAsync(s=>s.Id == id);

            if(statistic == null)
                return NotFound();

            _context.Statistics.Remove(statistic);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
