using AutoMapper;
using BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO;
using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.BisnesTaskDetails;
using BisnesManager.RequestsApp.Common.Mappings;

namespace API._Система_учета_сотрудников._Дипломный_проект.Models.BisnesTask
{
    public class UpdateBisnesTaskDto : IMapWith<BisnesTaskUpdateCommandDTO>
    {
        public int Id { get; set; }

        public string Content { get; set; } = null!;

        public int? Indentation { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string? AssignmentsContent { get; set; }

        public short IdStatus { get; set; }

        public DateOnly DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBisnesTaskDto, BisnesTaskUpdateCommandDTO>()
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
                .ForMember(bisnesTaskVm => bisnesTaskVm.IdStatus,
                  opt => opt.MapFrom(bisnesTask => bisnesTask.IdStatus));
        }
    }
}
