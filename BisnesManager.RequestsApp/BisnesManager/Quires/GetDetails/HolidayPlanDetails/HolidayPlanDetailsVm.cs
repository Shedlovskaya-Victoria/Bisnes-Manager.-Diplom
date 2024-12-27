using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.HolidayPlanDetails
{
    public class HolidayPlanDetailsVm : IMapWith<HolidayPlan>
    {
        public int Id { get; set; }
        public short IdUser { get; set; }
        public DateOnly DateCreate { get; set; }
        public DateOnly StartWeekends { get; set; }

        public DateOnly EndWeekends { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HolidayPlan, HolidayPlanDetailsVm>()
                .ForMember(holidayPlanVm => holidayPlanVm.StartWeekends,
                  opt => opt.MapFrom(holidayPLan => holidayPLan.StartWeekends))
                .ForMember(holidayPlanVm => holidayPlanVm.EndWeekends,
                  opt => opt.MapFrom(holidayPlan => holidayPlan.EndWeekends))
                .ForMember(holidayPlanVm => holidayPlanVm.DateCreate,
                  opt => opt.MapFrom(holidayPlan => holidayPlan.DateCreate))
                .ForMember(holidayPlanVm => holidayPlanVm.Id,
                  opt => opt.MapFrom(holidayPlan => holidayPlan.Id));
        }
    }
}
