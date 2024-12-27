using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails
{
    public class GetDetailsBasnesTaskValidation : AbstractValidator<BisnesTaskDetailsVm>
    {
        public GetDetailsBasnesTaskValidation()
        {
            RuleFor(task => task.IdUser).NotNull().NotEmpty();
            RuleFor(task => task.Id).NotNull().NotEmpty();
            RuleFor(task => task.DateCreate).NotNull().NotEmpty();
            RuleFor(task => task.EndDate).NotNull().NotEmpty();
            RuleFor(task => task.Content).NotNull().NotEmpty();
            RuleFor(task => task.IdStatus).NotNull().NotEmpty();
            
        }
    }
}
