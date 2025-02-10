using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.update_DTO
{
    public class UpdatePlanDto
    {
        public short IdUser { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime StartWeekends { get; set; }

        public DateTime EndWeekends { get; set; }
    }
}
