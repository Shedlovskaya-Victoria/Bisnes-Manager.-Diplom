using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandHandler
{
    public class CreateStatisticCommandHandler : ImplementBase<Statistic>, IRequestHandler<StatisticCreateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;

        public CreateStatisticCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(StatisticCreateCommandDTO request, CancellationToken cancellationToken)
        {
            var statistic = new Statistic()
            {
                IdUser = request.IdUser,
                QualityWork = request.QualityWork,
                EffectivCommunication = request.EffectivCommunication,
                HardSkils = request.HardSkils,
                SoftSkils = request.SoftSkils,
                LevelResponibility = request.LevelResponibility,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
            };

            await _context.Statistics.AddAsync(statistic);
            await SaveAsync();
        }
    }
}
