using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatusesLlist
{
    public class StatusListValidation : AbstractValidator<StatusListDto>
    {
        public StatusListValidation() 
        {
            RuleFor(plan => plan.Title).NotNull().NotEmpty();
        }
    }
}
