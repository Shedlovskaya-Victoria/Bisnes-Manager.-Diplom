using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatusesLlist
{
    internal class StatusQuery : IRequest<StatusVm>
    {
        public short Id { get; set; }
    }
}
