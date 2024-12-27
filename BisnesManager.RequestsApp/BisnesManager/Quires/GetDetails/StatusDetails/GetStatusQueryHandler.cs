using AutoMapper;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.UserDetails;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatusDetails
{
    public class GetStatusQueryHandler : IRequestHandler<GetStatusDetails, StatusDetailsVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetStatusQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatusDetailsVm> Handle(GetStatusDetails request, CancellationToken cancellationToken)
        {
            var entry = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == request.Id);
            if (entry == null)
            {
                throw new NotFoundException(nameof(Status), request.Id);
            }
            return _mapper.Map<StatusDetailsVm>(entry);
        }
    }
}
