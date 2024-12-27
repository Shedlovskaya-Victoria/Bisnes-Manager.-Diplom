using AutoMapper;
using AutoMapper.QueryableExtensions;
using BisnesManager.DatabasePersistens.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.GetBisnesTasksList
{
    public class GetBisnesTaskQueryHandler : IRequestHandler<GetBisnesTaskListQuery, BisnesTaskListVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetBisnesTaskQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BisnesTaskListVm> Handle(GetBisnesTaskListQuery request, CancellationToken cancellationToken)
        {
           var bisnesTaskQuery = await _context.BisnesTasks.Where(task=>task.IdUser == request.IdUser)
                .ProjectTo<GetListBisnesTaskDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new BisnesTaskListVm { BisnesTasks = bisnesTaskQuery };
        }
    }
}
