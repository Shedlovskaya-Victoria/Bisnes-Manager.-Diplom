using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.Validation
{
    public class UpdateStatusValidation  : AbstractValidator<StatusUpdateCommandDTO>
    {
       public UpdateStatusValidation() 
       {
            RuleFor(status=>status.Title).NotNull().NotEmpty(); 
            RuleFor(status=>status.Id).NotNull().NotEmpty(); 
       }
    }
}
