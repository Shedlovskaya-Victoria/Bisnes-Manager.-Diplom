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
    public class UsersController : ControllerBase
    {
        private readonly BissnesExpertSystemDiploma7Context context;
        private readonly UserRepository _userRepo;

        public UsersController(BissnesExpertSystemDiploma7Context context, UserRepository userRepo)
        {
            this.context = context;
            _userRepo = userRepo;
        }
        [HttpGet]
        public  async Task<IActionResult> GetAll([FromQuery] SortQueryDto query)
        {
            var list = await _userRepo.GetAllAsync(query);
            if(list == null) return NotFound();
            var listDto = list.Select(s=>s.ToUserDTO());
            return Ok(listDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] short id)
        {
            var data = await context.Users.Include(s => s.IdRoleNavigation).FirstOrDefaultAsync(s=>s.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data.ToUserDTO());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDtoRequest dtoRequest)
        {
            if (dtoRequest == null)
                return NotFound();

            var userModel = dtoRequest.ToUserFromCreateDTO();

           await _userRepo.CreateAsync(userModel);

            var returnValue = await context.Users
                .Include(s => s.IdRoleNavigation)
                .FirstOrDefaultAsync(s => s.Id == userModel.Id);

            if (returnValue == null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { userModel.Id }, returnValue.ToUserDTO() );
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserDto updateDto)
        {
            if (updateDto == null)
                return NotFound();

            var user = await _userRepo.UpdateAsync(id, updateDto);           

            if(user == null) return NotFound();

            return Ok(user.ToUserDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] short id)
        {
            var user = await _userRepo.DeleteAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
