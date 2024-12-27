using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatusDetails
{
    public class GetDetailsStatusValidation : AbstractValidator<StatusDetailsVm>
    {
        public GetDetailsStatusValidation() 
        {
            RuleFor(status => status.Title).NotNull().NotEmpty();
            RuleFor(status => status.Id).NotNull().NotEmpty();
        }
    }
}
