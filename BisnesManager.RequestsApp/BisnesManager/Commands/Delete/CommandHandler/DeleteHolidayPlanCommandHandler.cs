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
    public class DeleteHolidayPlanCommandHandler : ImplementBase<HolidayPlan>, IRequestHandler<HolidayPlanDeleteCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteHolidayPlanCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

      

        async Task<Unit> IRequestHandler<HolidayPlanDeleteCommandDTO, Unit>.Handle(HolidayPlanDeleteCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.HolidayPlans.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)   throw new NotFoundException(nameof(HolidayPlan), request.Id);
            

            await DeleteAsync(entry.Id);

            await SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
