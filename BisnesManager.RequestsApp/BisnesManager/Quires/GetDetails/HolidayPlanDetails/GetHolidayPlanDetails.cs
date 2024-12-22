using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.HolidayPlanDetails
{
    public class GetHolidayPlanDetails : IRequest<HolidayPlanVm>
    {
        public short Id { get; set; }
        public short IdUser { get; set; }
    }
}
