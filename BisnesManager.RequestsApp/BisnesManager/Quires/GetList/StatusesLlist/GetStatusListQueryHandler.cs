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

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatusesLlist
{ 
    internal class GetStatusListQueryHandler : IRequestHandler<StatusQuery ,StatusVm> 
    {
        private readonly BissnesExpertSystemDiplomaContext _context; 
        private readonly IMapper _mapper;
        public GetStatusListQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusVm> Handle(StatusQuery request, CancellationToken cancellationToken)
        {
            var statusesQuery = await _context.Statuses.Where(status => status.Id == request.Id)
                 .ProjectTo<StatusListDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new StatusVm {  Statuses  = statusesQuery };
        }
    }
}
