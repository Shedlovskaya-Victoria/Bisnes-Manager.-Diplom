using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.DTO
{
    public class HolidayPlanDTO
    {
        public short IdUser { get; set; }

        public DateOnly StartWeekends { get; set; }

        public DateOnly EndWeekends { get; set; }
    }
}
