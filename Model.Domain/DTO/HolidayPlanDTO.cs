using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Domain.DTO
{
    public class HolidayPlanDTO
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

        public DateOnly DateCreate { get; set; }
        public DateOnly StartWeekends { get; set; }

        public DateOnly EndWeekends { get; set; }
    }
}
