using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO
{
    public class HolidayPlanDeleteCommandDTO : IRequest
    {

        public short Id { get; set; }
        public short IdUser { get; set; }

    }
}
