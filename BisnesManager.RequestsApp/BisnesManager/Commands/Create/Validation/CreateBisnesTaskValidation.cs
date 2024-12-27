using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.Validation
{
    public class CreateBisnesTaskValidation : AbstractValidator<BisnesTaskCreateCommandDTO>
    {
        public CreateBisnesTaskValidation()
        {
            RuleFor(createTask=>createTask.Content).NotEmpty().MaximumLength(250);
            RuleFor(createTask => createTask.IdUser).NotNull().NotEmpty();
            RuleFor(createTask => createTask.EndDate).NotNull().NotEmpty();
            RuleFor(createTask => createTask.DateCreate).NotNull().NotEmpty();
            RuleFor(createTask => createTask.IdStatus).NotNull().NotEmpty();
        }
    }
}
