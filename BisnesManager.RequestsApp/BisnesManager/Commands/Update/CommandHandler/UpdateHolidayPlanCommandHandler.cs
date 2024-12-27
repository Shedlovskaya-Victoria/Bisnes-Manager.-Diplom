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
    public class DeleteHolidayPlanCommandHandler : ImplementBase<HolidayPlan>, IRequestHandler<HolidayPlanUpdateCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public DeleteHolidayPlanCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(HolidayPlanUpdateCommandDTO request, CancellationToken cancellationToken)
        {
            var entry = await _context.HolidayPlans.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entry == null)
            {
                throw new NotFoundException(nameof(HolidayPlan), request.Id);
            }

            entry.EndWeekends = request.EndWeekends;
            entry.StartWeekends = request.StartWeekends;
            entry.IdUser = request.IdUser;
            entry.DateCreate = DateOnly.FromDateTime(DateTime.Now);
            
            await SaveAsync(cancellationToken);
        }
    }
}
