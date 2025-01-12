//using BisnesManager.RequestsApp.BisnesManager.Quires.GetList.GetBisnesTasksList;
//using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails;
using BisnesManager.WebAPI.Diplom;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API._Система_учета_сотрудников._Дипломный_проект.Models.BisnesTask;
//using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
//using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
//using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;

namespace API._Система_учета_сотрудников._Дипломный_проект.Controllers
{
    //[Route("api/[controller]")]
    //public class BisnesTaskController : BaseController
    //{
    //    private readonly IMapper _mapper;

    //    public BisnesTaskController(IMapper mapper) => _mapper = mapper;

    //    [HttpGet]
    //    public async Task<ActionResult<BisnesTaskListVm>> GetAll()
    //    {
    //        var query = new GetBisnesTaskListQuery()
    //        {
    //            IdUser = (short)UserId
    //        };
    //        var vm = await Mediator.Send(query);
    //        return Ok(vm);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<BisnesTaskDetailsVm>> Get(int id)
    //    {
    //        var query = new GetBisnesTaskDetailsQuery
    //        {
    //            IdUser = (short)UserId,
    //            Id = id
    //        };
    //        var vm = await Mediator.Send(query);
    //        return Ok(vm);
    //    }
    //    [HttpPost]
    //    public async Task<ActionResult<int>> Create([FromBody] CreateBisnesTaskDto createBisnesTask)
    //    {
    //        var command = _mapper.Map<BisnesTaskCreateCommandDTO>(createBisnesTask);
    //        command.IdUser = (short)UserId;
    //        await Mediator.Send(command);
    //        return Ok();
    //    }
    //    [HttpPut]
    //    public async Task<ActionResult> Update([FromBody] UpdateBisnesTaskDto updateBisnesTask)
    //    {
    //        var command = _mapper.Map<BisnesTaskUpdateCommandDTO>(updateBisnesTask);
    //        command.IdUser = (short)UserId;
    //        await Mediator.Send(command);
    //        return NoContent();
    //    }
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var command = new BisnesTaskDeleteCommandDTO
    //        {
    //            Id = id,
    //            IdUser = (short)UserId
    //        };
    //        await Mediator.Send(command);
    //        return NoContent();
    //    }
    //}
}
