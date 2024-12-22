using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.RequestsApp.Common.Exception;
using Microsoft.EntityFrameworkCore;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandHandler
{
    public class RoleCommandHandler : ImplementBase<Role>, IRequestHandler<RoleCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public RoleCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(RoleCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);

        }
    }
}
