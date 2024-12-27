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

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatisticsList
{
    internal class GetStatisticsListQueryHandler : IRequestHandler<StatisticsQuery, StatisticsVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetStatisticsListQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatisticsVm> Handle(StatisticsQuery request, CancellationToken cancellationToken)
        {
            var statisticQuery = await _context.Statistics.Where(stat => stat.IdUser == request.IdUser)
                .ProjectTo<StatisticsListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new StatisticsVm { Statistics = statisticQuery };
        }
    }
}
