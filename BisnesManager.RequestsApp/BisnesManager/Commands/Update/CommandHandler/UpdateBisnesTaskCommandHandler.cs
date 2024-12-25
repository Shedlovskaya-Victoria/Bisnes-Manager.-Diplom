using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandHandler
{
    public class DeleteBisnesTaskCommandHandler : ImplementBase<BisnesTask>, IRequestHandler<BisnesTaskUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteBisnesTaskCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(BisnesTaskUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.BisnesTasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(BisnesTask), request.Id);
            }

            entry.AssignmentsContent = request.AssignmentsContent;
            entry.Content = request.Content;
            entry.DateCreate = DateOnly.FromDateTime(DateTime.Now);
            entry.StartDate = request.StartDate;
            entry.EndDate = request.EndDate;
            entry.IdStatus = request.IdStatus;
            entry.IdUser = request.IdUser;
            entry.Indentation = request.Indentation;
           

            await SaveAsync(cancellationToken);
        }
    }
}
