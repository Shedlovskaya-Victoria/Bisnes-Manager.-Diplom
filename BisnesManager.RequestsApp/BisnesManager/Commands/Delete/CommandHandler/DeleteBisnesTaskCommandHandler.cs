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
    public class DeleteBisnesTaskCommandHandler : ImplementBase<BisnesTask>, IRequestHandler<BisnesTaskDeleteCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteBisnesTaskCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(BisnesTaskDeleteCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.BisnesTasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(BisnesTask), request.Id);
            }

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);
        }
    }
}
