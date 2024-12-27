using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.Validation
{
    public class CreateHolidayPlanValidation : AbstractValidator<HolidayPlanCreateCommandDTO>
    {
        public CreateHolidayPlanValidation() 
        {
            RuleFor(plan=>plan.EndWeekends).NotNull().NotEmpty();
            RuleFor(plan=>plan.StartWeekends).NotNull().NotEmpty();
            RuleFor(plan=>plan.IdUser).NotNull().NotEmpty();
            RuleFor(plan=>plan.DateCreate).NotNull().NotEmpty();
        }
    }
}
