using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.HolidayPlanList
{
    public class HolidayPlanListDto : IMapWith<HolidayPlan>
    {
        public int Id { get; set; }
        public DateOnly DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HolidayPlan, HolidayPlanListDto>()
                .ForMember(holidayPlanDto => holidayPlanDto.DateCreate,
                  opt => opt.MapFrom(holidayPlan => holidayPlan.DateCreate))
                .ForMember(holidayPlanDto => holidayPlanDto.Id,
                  opt => opt.MapFrom(holidayPlan => holidayPlan.Id));

        }
    }
}
