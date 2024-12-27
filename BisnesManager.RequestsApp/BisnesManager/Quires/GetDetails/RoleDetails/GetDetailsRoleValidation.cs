using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.RoleDetails
{
    public class GetDetailsRoleValidation : AbstractValidator<RoleDetailsVm>
    {
        public GetDetailsRoleValidation() 
        {
            RuleFor(role => role.Id).NotNull().NotEmpty();
            RuleFor(role => role.Title).NotNull().NotEmpty();
            RuleFor(role => role.IsEditWorkersRoles).NotNull().NotEmpty();
            RuleFor(role => role.IsEditWorkTimeTable).NotNull().NotEmpty();
        }
    }
}
