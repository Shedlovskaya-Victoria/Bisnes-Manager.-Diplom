using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.HolidayPlanDetails
{
    public class GetDetailsHolidayPlanValidation : AbstractValidator<HolidayPlanDetailsVm>
    {
        public GetDetailsHolidayPlanValidation()
        {
            RuleFor(plan => plan.EndWeekends).NotNull().NotEmpty();
            RuleFor(plan => plan.StartWeekends).NotNull().NotEmpty();
            RuleFor(plan => plan.IdUser).NotNull().NotEmpty();
            RuleFor(plan => plan.Id).NotNull().NotEmpty();
            RuleFor(plan => plan.DateCreate).NotNull().NotEmpty();
        }
    }
}
