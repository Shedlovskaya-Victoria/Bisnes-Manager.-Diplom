using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Create.CommandDTO
{
    public class HolidayPlanCreateCommandDTO : IRequest
    {
        public short IdUser { get; set; }

        public DateOnly DateCreate { get; set; }
        public DateOnly StartWeekends { get; set; }

        public DateOnly EndWeekends { get; set; }
    }
}
