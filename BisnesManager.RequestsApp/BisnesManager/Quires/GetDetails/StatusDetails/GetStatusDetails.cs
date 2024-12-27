using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatusDetails
{
    public class GetStatusDetails : IRequest<StatusDetailsVm>
    {
        public short Id { get; set; }


    }
}
