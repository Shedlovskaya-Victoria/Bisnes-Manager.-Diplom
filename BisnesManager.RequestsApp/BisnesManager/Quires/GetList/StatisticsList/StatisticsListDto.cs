using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatisticsList
{
    public class StatisticsListDto : IMapWith<Statistic>
    {
        public int Id { get; set; }

        public DateOnly DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Statistic, StatisticsListDto>()
                  .ForMember(statVm => statVm.Id,
                    opt => opt.MapFrom(stat => stat.Id))
                  .ForMember(statVm => statVm.DateCreate,
                    opt => opt.MapFrom(stat => stat.DateCreate));
        }
    }
}
