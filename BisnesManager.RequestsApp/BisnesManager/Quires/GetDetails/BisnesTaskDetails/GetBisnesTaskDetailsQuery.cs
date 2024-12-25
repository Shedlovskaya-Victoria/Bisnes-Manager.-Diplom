using BisnesManager.DatabasePersistens.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails
{
    public class GetBisnesTaskDetailsQuery : IRequest<BisnesTaskDetailsVm>
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

    }
}
