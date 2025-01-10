using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.RequestsApp.Common.Exception;
using Microsoft.EntityFrameworkCore;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandHandler
{
    public class RoleCommandHandler : ImplementBase<Role>, IRequestHandler<RoleUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public RoleCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

       

        async Task<Unit> IRequestHandler<RoleUpdateCommandDTO, Unit>.Handle(RoleUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            entry.IsEditWorkersRoles = request.IsEditWorkersRoles;
            entry.IsEditWorkTimeTable = request.IsEditWorkTimeTable;
            entry.DateCreate = DateOnly.FromDateTime(DateTime.Now);
            entry.Post = request.Post;
            entry.Title = request.Title;

            await SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
