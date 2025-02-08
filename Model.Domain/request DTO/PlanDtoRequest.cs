using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.request_DTO
{
    public class PlanDtoRequest
    {
        public short IdUser { get; set; }

        public DateTime StartWeekends { get; set; }

        public DateTime EndWeekends { get; set; }

    }
}
