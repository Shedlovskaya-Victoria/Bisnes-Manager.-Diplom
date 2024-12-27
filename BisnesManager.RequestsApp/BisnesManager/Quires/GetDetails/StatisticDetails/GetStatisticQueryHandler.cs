using AutoMapper;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.HolidayPlanDetails;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatisticDetails
{
    public class GetStatisticQueryHandler : IRequestHandler<GetStatisticDetails, StatisticDetailsVm>
    {

        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetStatisticQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatisticDetailsVm> Handle(GetStatisticDetails request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statistics.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(Statistic), request.Id);
            }
            return _mapper.Map<StatisticDetailsVm>(entry);
        }
    }
}
