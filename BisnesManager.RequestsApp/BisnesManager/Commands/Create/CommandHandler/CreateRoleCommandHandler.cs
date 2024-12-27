using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandHandler
{
    public class CreateRoleCommandHandler : ImplementBase<Role>, IRequestHandler<RoleCreateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public CreateRoleCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(RoleCreateCommandDTO request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                IsEditWorkersRoles = request.IsEditWorkersRoles,
                IsEditWorkTimeTable = request.IsEditWorkTimeTable,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
                Post = request.Post,
                Title = request.Title,

            };

            await _context.Roles.AddAsync(role);
            await SaveAsync();

        }
    }
}
