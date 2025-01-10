using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.HolidayPlanList
{
    public class HolidayPlanVm
    {
        public List<HolidayPlanListDto> holidayPlansList { get; set; } = new();
    }
}
