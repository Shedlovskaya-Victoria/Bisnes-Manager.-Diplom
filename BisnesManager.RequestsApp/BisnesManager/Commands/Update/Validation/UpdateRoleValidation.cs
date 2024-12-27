using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.Validation
{
    public class UpdateRoleValidation : AbstractValidator<RoleUpdateCommandDTO>
    {
        public UpdateRoleValidation() 
        {
            RuleFor(role=>role.Id).NotNull().NotEmpty();
            RuleFor(role=>role.Title).NotNull().NotEmpty();
            RuleFor(role=>role.IsEditWorkersRoles).NotNull().NotEmpty();
            RuleFor(role=>role.IsEditWorkTimeTable).NotNull().NotEmpty();
        }
    }
}
