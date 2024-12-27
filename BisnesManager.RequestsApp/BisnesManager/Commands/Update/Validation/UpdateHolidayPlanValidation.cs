using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.Validation
{
    public class UpdateHolidayPlanValidation : AbstractValidator<HolidayPlanUpdateCommandDTO>
    {
        public UpdateHolidayPlanValidation() 
        {
            RuleFor(plan=>plan.EndWeekends).NotNull().NotEmpty();
            RuleFor(plan=>plan.StartWeekends).NotNull().NotEmpty();
            RuleFor(plan=>plan.IdUser).NotNull().NotEmpty();
            RuleFor(plan=>plan.Id).NotNull().NotEmpty();
            RuleFor(plan=>plan.DateCreate).NotNull().NotEmpty();
        }
    }
}
