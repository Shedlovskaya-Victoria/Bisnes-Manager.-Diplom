using BisnesManager.Database.Context;
using BisnesManager.Database.Model;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.Repositories;
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
        private readonly StatisticRepository _statisticRepo;
        public StatisticsController(StatisticRepository statisticRepo)
        {
            _statisticRepo = statisticRepo;
        }
        [HttpGet]
        public async Task<IActionResult> FilterAllByDate([FromQuery] FilterDateQueryDto query) 
        {
            var list = await _statisticRepo.GetAllAsync(query);
            if (list == null) return NotFound();
            var listDto = list.Select(s => s.ToStatisticDTO());

            return Ok(listDto);
        }
        [HttpPost("GetAllByUserId")]
        public async Task<IActionResult> GetAllByUserId([FromBody] short UserId)
        {
            var list = await _statisticRepo.GetAllByIdAsync(UserId);
            if (list == null) return NotFound();
            var listDto = list.Select(s => s.ToStatisticDTO());
             
            return Ok(listDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await _statisticRepo.GetByIdAsync(id);
             
            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatisticDTO());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] StatisticDtoRequest dtoRequest)
        {
            if (dtoRequest == null) return NotFound();
            var statisticModel = dtoRequest.ToStatisticFromCreateDTO();
            await _statisticRepo.CreateAsync(statisticModel);
            return CreatedAtAction(nameof(GetById), new { statisticModel.Id }, statisticModel.ToStatisticDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStatisticDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var statistic = await _statisticRepo.UpdateAsync(id, updateDto);
            if(statistic == null) return NotFound();
            return Ok(statistic.ToStatisticDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var statistic = await _statisticRepo.DeleteAsync(id);

            if(statistic == null)
                return NotFound();


            return NoContent();
        }
    }
}
