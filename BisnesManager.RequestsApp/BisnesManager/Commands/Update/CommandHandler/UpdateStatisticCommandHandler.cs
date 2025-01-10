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
    public class DeleteStatisticCommandHandler : ImplementBase<Statistic>, IRequestHandler<StatisticUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;

        public DeleteStatisticCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

       

        async Task<Unit> IRequestHandler<StatisticUpdateCommandDTO, Unit>.Handle(StatisticUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(Statistic), request.Id);
            }

            entry.IdUser = request.IdUser;
            entry.QualityWork = request.QualityWork;
            entry.EffectivCommunication = request.EffectivCommunication;
            entry.HardSkils = request.HardSkils;
            entry.SoftSkils = request.SoftSkils;
            entry.LevelResponibility = request.LevelResponibility;
            entry.DateCreate = DateOnly.FromDateTime(DateTime.Now);


            await SaveAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
