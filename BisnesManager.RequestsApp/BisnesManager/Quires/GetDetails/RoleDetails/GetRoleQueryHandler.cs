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

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.RoleDetails
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleDetails, RoleDetailsVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetRoleQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<RoleDetailsVm> IRequestHandler<GetRoleDetails, RoleDetailsVm>.Handle(GetRoleDetails request, CancellationToken cancellationToken)
        {
            var entry = await _context.Roles.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

            if (entry == null )
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }
            return _mapper.Map<RoleDetailsVm>(entry);
        }
    }
}
