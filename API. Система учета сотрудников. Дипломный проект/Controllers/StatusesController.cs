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
    public class StatusesController : ControllerBase
    {
        private BissnesExpertSystemDiploma7Context context;

        public StatusesController(BissnesExpertSystemDiploma7Context context)
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
        [HttpPost]
        public IActionResult Create([FromBody] StatusDtoRequest dtoRequest)
        {
            var statusModel = dtoRequest.ToStatus();
            context.Statuses.Add(statusModel);
            context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { statusModel.Id}, statusModel.ToStatusDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStatusDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

            var statusModel = context.Statuses.FirstOrDefault(s => s.Id == id);

            statusModel.Title = updateDto.Title;
            context.SaveChanges();

            return Ok(statusModel.ToStatusDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var status = context.Statuses.FirstOrDefault(s=>s.Id == id);

            if(status == null)
                return NotFound();

            context.Statuses.Remove(status);

            context.SaveChanges();

            return NoContent();
        }
    }
}
