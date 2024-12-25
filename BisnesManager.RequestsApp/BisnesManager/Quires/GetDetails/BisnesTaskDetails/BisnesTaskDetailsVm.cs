using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails
{
    public class BisnesTaskDetailsVm : IMapWith<BisnesTask>
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

        public string Content { get; set; } = null!;

        public int? Indentation { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string? AssignmentsContent { get; set; }

        public short IdStatus { get; set; }

        public DateOnly DateCreate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<BisnesTask, BisnesTaskDetailsVm>()
                .ForMember(bisnesTaskVm => bisnesTaskVm.Id,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.Id))
                .ForMember(bisnesTaskVm => bisnesTaskVm.IdStatus,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.IdStatus))
                .ForMember(bisnesTaskVm => bisnesTaskVm.Content,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.Content))
                .ForMember(bisnesTaskVm => bisnesTaskVm.AssignmentsContent,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.AssignmentsContent))
                .ForMember(bisnesTaskVm => bisnesTaskVm.DateCreate,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.DateCreate))
                .ForMember(bisnesTaskVm => bisnesTaskVm.EndDate,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.EndDate))
                .ForMember(bisnesTaskVm => bisnesTaskVm.Indentation,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.Indentation))
                .ForMember(bisnesTaskVm => bisnesTaskVm.IdUser,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.IdUser))
                .ForMember(bisnesTaskVm => bisnesTaskVm.IdStatus,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.IdStatus));
        }
    }
}
