using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.HolidayPlanList
{
    internal class HolidayPlansQuery : IRequest<HolidayPlanVm>
    {
        public short IdUser { get; set; }
    }
}
