using AutoMapper;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Exception;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.UserDetails
{
    public class GetUserQueryHandler : IRequestHandler<GetUserDetails, UserDetailsVm>
    {
        private readonly BissnesExpertSystemDiplomaContext _context;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(BissnesExpertSystemDiplomaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserDetailsVm> Handle(GetUserDetails request, CancellationToken cancellationToken)
        {
            var entry = await _context.Users.FirstOrDefaultAsync(s=>s.Id == request.Id);
            if (entry == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }
            return _mapper.Map<UserDetailsVm>(entry);
        }
    }
}
