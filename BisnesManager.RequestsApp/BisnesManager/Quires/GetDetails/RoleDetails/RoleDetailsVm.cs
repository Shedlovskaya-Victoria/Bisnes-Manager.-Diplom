using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.RoleDetails
{
    public class RoleDetailsVm : IMapWith<Role>
    {
        public short Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsEditWorkersRoles { get; set; }

        public bool IsEditWorkTimeTable { get; set; }

        public string? Post { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Role, RoleDetailsVm>()
                .ForMember(roleVm => roleVm.Id,
                  opt => opt.MapFrom(role => role.Id))
                .ForMember(roleVm => roleVm.Title,
                  opt => opt.MapFrom(role => role.Title))
                .ForMember(roleVm => roleVm.IsEditWorkersRoles,
                  opt => opt.MapFrom(role => role.IsEditWorkersRoles))
                .ForMember(roleVm => roleVm.IsEditWorkTimeTable,
                  opt => opt.MapFrom(role => role.IsEditWorkTimeTable))
                .ForMember(roleVm => roleVm.Post,
                  opt => opt.MapFrom(role => role.Post));
                
        }
    }
}
