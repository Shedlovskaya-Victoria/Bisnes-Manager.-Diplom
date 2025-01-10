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
    public class StatusListDto : IMapWith<Status>
    {

        public string Title { get; set; } = "";

        public static void Mapper(Profile profile)
        {
            profile.CreateMap<Status, StatusListDto>()
                  .ForMember(userDto => userDto.Title,
                  opt => opt.MapFrom(user => user.Title));

        }
    }
}
