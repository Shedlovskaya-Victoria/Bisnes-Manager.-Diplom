using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.GetBisnesTasksList
{
    public class GetListBisnesTaskDto : IMapWith<BisnesTask>
    {
        public int Id { get; set; }

        public DateOnly StartDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<BisnesTask, GetListBisnesTaskDto>()
                .ForMember(bisnesTaskDto => bisnesTaskDto.Id,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.Id))
                .ForMember(bisnesTaskDto => bisnesTaskDto.StartDate,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.StartDate));
        }

    }
}
