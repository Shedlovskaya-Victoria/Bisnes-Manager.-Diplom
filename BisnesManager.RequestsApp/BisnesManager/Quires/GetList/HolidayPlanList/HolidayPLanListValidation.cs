using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.HolidayPlanList
{
    public class HolidayPLanListValidation : AbstractValidator<HolidayPlanListDto>
    {
        public HolidayPLanListValidation()
        {
            RuleFor(plan => plan.Id).NotNull().NotEmpty();
            RuleFor(plan => plan.DateCreate).NotNull().NotEmpty();
        }
    }
}
