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
    public class DeleteStatisticCommandHandler : ImplementBase<Statistic>, IRequestHandler<StatisticCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;

        public DeleteStatisticCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(StatisticCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(Statistic), request.Id);
            }

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);
        }
    }
}
