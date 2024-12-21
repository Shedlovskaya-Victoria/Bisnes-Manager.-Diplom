using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Domain.DTO
{
    public class HolidayPlan
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

        public DateOnly Date { get; set; }
    }
}
