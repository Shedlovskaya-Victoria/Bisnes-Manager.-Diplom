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
    public class CreateHolidayPlanCommandHandler : ImplementBase<HolidayPlan>, IRequestHandler<HolidayPlanCommandDTO>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        public CreateHolidayPlanCommandHandler(BissnesExpertSystemDiplomaContext context) : base(context)
        {
            _context = context;
        }

        public async Task Handle(HolidayPlanCommandDTO request, CancellationToken cancellationToken)
        {
            var holidayPlan = new HolidayPlan()
            {
                EndWeekends = request.EndWeekends,
                StartWeekends = request.StartWeekends,
                IdUser = request.IdUser,
                DateCreate = DateOnly.FromDateTime(DateTime.Now),
            };

            await _context.HolidayPlans.AddAsync(holidayPlan);
            await SaveAsync();
        }
    }
}
