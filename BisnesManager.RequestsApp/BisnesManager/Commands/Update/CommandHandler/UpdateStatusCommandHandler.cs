using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandHandler
{
    public class DeleteStatusCommandHandler : ImplementBase<Status>, IRequestHandler<StatusUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteStatusCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }


        async Task<Unit> IRequestHandler<StatusUpdateCommandDTO, Unit>.Handle(StatusUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statuses.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }

            entry.Title = request.Title;


            await SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
