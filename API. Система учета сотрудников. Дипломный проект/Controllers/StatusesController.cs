
using BisnesManager.Database.Models;
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
    public class StatusesController : ControllerBase
    {
        private readonly StatusRepository _statusRepo;

        public StatusesController(StatusRepository statusRepo)
        {
            _statusRepo = statusRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _statusRepo.GetAllAsync();
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToStatusDTO());
            return Ok(listDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
        {
            var data = await _statusRepo.GetByIdAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToStatusDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StatusDtoRequest dtoRequest)
        {            
            var statusModel = dtoRequest.ToStatus();
            await _statusRepo.CreateAsync(statusModel);
            return CreatedAtAction(nameof(GetById), new { statusModel.Id}, statusModel.ToStatusDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStatusDto updateDto)
        {
            if(updateDto == null)
                return NotFound();

            var statusModel = await _statusRepo.UpdateAsync(id, updateDto);           
            if(statusModel == null) return NotFound();
            return Ok(statusModel.ToStatusDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            var status = await _statusRepo.DeleteAsync(id);

            if(status == null)
                return NotFound();

            return NoContent();
        }
    }
}
