using AutoMapper;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Commands;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.HolidayPlanDetails
{
    public class GetHolidayPlanQueryHandler : IRequestHandler<GetHolidayPlanDetails, HolidayPlanDetailsVm>
    {

        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetHolidayPlanQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)  
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HolidayPlanDetailsVm> Handle(GetHolidayPlanDetails request, CancellationToken cancellationToken)
        {
           var entry = await _context.HolidayPlans.FirstOrDefaultAsync(s=>s.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(HolidayPlan), request.Id);
            }
            return _mapper.Map<HolidayPlanDetailsVm>(entry);
        }
    }
}
