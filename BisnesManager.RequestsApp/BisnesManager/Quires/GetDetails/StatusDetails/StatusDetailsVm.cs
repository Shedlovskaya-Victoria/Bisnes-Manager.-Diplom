using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatusDetails
{
    public class StatusDetailsVm : IMapWith<Status>
    {
        public short Id { get; set; }

        public string Title { get; set; } = "";

        public void Mapper(Profile profile)
        {
            profile.CreateMap<Status, StatusDetailsVm>()
                .ForMember(userVm => userVm.Id,
                  opt => opt.MapFrom(user => user.Id))
                  .ForMember(userVm => userVm.Title,
                  opt => opt.MapFrom(user => user.Title));

        }
    }
}
