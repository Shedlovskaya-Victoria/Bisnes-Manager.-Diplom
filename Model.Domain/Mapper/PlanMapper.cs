using BisnesManager.Database.Model;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
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
                Id = holidayPlan.Id,
                EndWeekends = holidayPlan.EndWeekends,
                StartWeekends = holidayPlan.StartWeekends,
                IdUser = holidayPlan.IdUser,
            };
        }
        public static HolidayPlan ToPlanFromCreateDTO(this PlanDtoRequest holidayPlan)
        {
            return new HolidayPlan
            {
                StartWeekends = DateOnly.FromDateTime( holidayPlan.StartWeekends),
                EndWeekends = DateOnly.FromDateTime(holidayPlan.EndWeekends),
                IdUser = holidayPlan.IdUser,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
            };
        }
    }
}
