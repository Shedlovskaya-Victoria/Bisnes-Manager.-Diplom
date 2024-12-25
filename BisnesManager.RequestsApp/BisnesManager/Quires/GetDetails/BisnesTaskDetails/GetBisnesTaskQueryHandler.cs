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

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails
{
    public class GetBisnesTaskQueryHandler : IRequestHandler<GetBisnesTaskDetailsQuery, BisnesTaskDetailsVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetBisnesTaskQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BisnesTaskDetailsVm> Handle(GetBisnesTaskDetailsQuery request, CancellationToken cancellationToken)
        {
            var entry = await _context.BisnesTasks.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (entry == null || entry.IdUser != request.IdUser)
            {
                throw new NotFoundException(nameof(BisnesTask), request.Id);
            }
            return _mapper.Map<BisnesTaskDetailsVm>(entry);
        }
    }
}
