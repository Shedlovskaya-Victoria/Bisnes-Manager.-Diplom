using BisnesManager.RequestsApp.Common.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.RoleDetails
{
    internal class GetRoleDetails : IRequest<RoleDetailsVm>
    {
        public short Id { get; set; }

    }
}
