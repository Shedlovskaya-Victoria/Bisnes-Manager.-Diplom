using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.Validation
{
    public class DeleteHolidayPlanValidation : AbstractValidator<HolidayPlanDeleteCommandDTO>
    {
        DeleteHolidayPlanValidation() 
        {
            RuleFor(task => task.IdUser).NotNull().NotEmpty();
            RuleFor(task => task.Id).NotNull().NotEmpty();
        }
    }
}
