using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatusDetails;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatusesLlist
{
    internal class StatusDto : IMapWith<Status>
    {

        public string Title { get; set; }

        public void Mapper(Profile profile)
        {
            profile.CreateMap<Status, StatusDto>()
                  .ForMember(userDto => userDto.Title,
                  opt => opt.MapFrom(user => user.Title));

        }
    }
}
