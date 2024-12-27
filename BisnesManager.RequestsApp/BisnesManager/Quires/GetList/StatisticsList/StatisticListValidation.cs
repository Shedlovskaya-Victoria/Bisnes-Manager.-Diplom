using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatisticsList
{
    public class StatisticListValidation : AbstractValidator<StatisticsListDto>
    {
        public StatisticListValidation() 
        {
            RuleFor(plan => plan.Id).NotNull().NotEmpty();
            RuleFor(plan => plan.DateCreate).NotNull().NotEmpty();
        }
    }
}
