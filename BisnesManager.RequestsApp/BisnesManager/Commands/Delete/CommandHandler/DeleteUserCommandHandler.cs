using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandHandler
{
    public class DeleteUserCommandHandler : ImplementBase<User>, IRequestHandler<UserDeleteCommandDTO, Unit>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteUserCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UserDeleteCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
