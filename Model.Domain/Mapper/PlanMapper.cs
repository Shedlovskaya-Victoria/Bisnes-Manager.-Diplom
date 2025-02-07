using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class PlanMapper
    {
        public static HolidayPlanDTO ToPlanDTO(this HolidayPlan holidayPlan)
        {
            return new HolidayPlanDTO
            {
                EndWeekends = holidayPlan.EndWeekends,
                StartWeekends = holidayPlan.StartWeekends,
                IdUser = holidayPlan.IdUser,
            };
        }
    }
}
