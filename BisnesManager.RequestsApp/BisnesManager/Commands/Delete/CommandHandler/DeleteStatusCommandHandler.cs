using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.Domain.DTO;
using BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandHandler
{
    public class DeleteStatusCommandHandler : ImplementBase<Status>, IRequestHandler<StatusCommandDTO, Unit>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteStatusCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(StatusCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
