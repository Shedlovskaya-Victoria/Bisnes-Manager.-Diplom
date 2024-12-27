using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.GetBisnesTasksList
{
    public class GetListBasnesTaskValidation : AbstractValidator<GetListBisnesTaskDto>
    {
        public GetListBasnesTaskValidation()
        {
            RuleFor(task => task.Id).NotNull().NotEmpty();
            RuleFor(task => task.StartDate).NotNull().NotEmpty();
            
        }
    }
}
