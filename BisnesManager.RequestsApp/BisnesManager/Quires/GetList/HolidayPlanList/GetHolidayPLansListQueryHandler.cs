using AutoMapper;
using AutoMapper.QueryableExtensions;
using BisnesManager.DatabasePersistens.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.HolidayPlanList
{
    internal class GetHolidayPLansListQueryHandler : IRequestHandler<HolidayPlansQuery, HolidayPlanVm>
    {

        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetHolidayPLansListQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<HolidayPlanVm> Handle(HolidayPlansQuery request, CancellationToken cancellationToken)
        {
           var holidayPlansQuery = await _context.HolidayPlans.Where(plan=>plan.IdUser == request.IdUser)
                .ProjectTo<HolidayPlanLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new HolidayPlanVm { holidayPlans = holidayPlansQuery };
        }
    }
}
