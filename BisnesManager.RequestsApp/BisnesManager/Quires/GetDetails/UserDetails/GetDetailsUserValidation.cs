using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.UserDetails
{
    public class GetDetailsUserValidation : AbstractValidator<UserDetailsVm>
    {
        public GetDetailsUserValidation() 
        {
            RuleFor(user => user.IdRole).NotNull().NotNull();
            RuleFor(user => user.Id).NotNull().NotNull();
            RuleFor(user => user.Email).NotNull().NotNull();
            RuleFor(user => user.DateCreate).NotNull().NotNull();
            RuleFor(user => user.EndWorkTime).NotNull().NotNull();
            RuleFor(user => user.CheckPhrase).NotNull().NotNull();
            RuleFor(user => user.Login).NotNull().NotNull();
            RuleFor(user => user.Family).NotNull().NotNull();
            RuleFor(user => user.Password).NotNull().NotNull();
            RuleFor(user => user.Patronymic).NotNull().NotNull();
            RuleFor(user => user.StartWorkTime).NotNull().NotNull();
            RuleFor(user => user.Name).NotNull().NotNull();
        }
    }
}
