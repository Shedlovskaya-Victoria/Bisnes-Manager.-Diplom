using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.Validation
{
    public class DeleteStatisticValidation : AbstractValidator<StatisticDeleteCommandDTO>
    {
        public DeleteStatisticValidation() 
        {
            RuleFor(task => task.Id).NotNull().NotEmpty();
            RuleFor(task => task.IdUser).NotNull().NotEmpty();
        }
    }
}
