using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.Validation
{
    public class CreateStatusValidation  : AbstractValidator<StatusCreateCommandDTO>
    {
       public CreateStatusValidation() 
       {
            RuleFor(status=>status.Title).NotNull().NotEmpty(); 
       }
    }
}
