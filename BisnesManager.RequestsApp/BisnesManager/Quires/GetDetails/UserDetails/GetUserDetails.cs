using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.UserDetails
{
    public class GetUserDetails : IRequest<UserDetailsVm>
    {
        public short Id { get; set; }

    }
}
