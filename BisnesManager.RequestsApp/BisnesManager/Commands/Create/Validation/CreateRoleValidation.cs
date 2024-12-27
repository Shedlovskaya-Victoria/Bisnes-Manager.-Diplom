using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.Validation
{
    public class CreateRoleValidation : AbstractValidator<RoleCreateCommandDTO>
    {
        public CreateRoleValidation() 
        {
            RuleFor(role=>role.Title).NotNull().NotEmpty();
            RuleFor(role=>role.IsEditWorkersRoles).NotNull().NotEmpty();
            RuleFor(role=>role.IsEditWorkTimeTable).NotNull().NotEmpty();
        }
    }
}
