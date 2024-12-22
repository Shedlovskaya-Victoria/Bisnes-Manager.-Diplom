using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.UserDetails
{
    public class UserVm : IMapWith<User>
    {
        public short Id { get; set; }

        public string Name { get; set; } = null!;

        public string Family { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CheckPhrase { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Login { get; set; } = null!;

        public short IdRole { get; set; }

        public byte[]? PhotoImage { get; set; }

        public DateTime? StartWorkTime { get; set; }

        public DateTimeOffset? EndWorkTime { get; set; }

        public DateOnly DateCreate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(uesrVm => uesrVm.Id,
                  opt => opt.MapFrom(user => user.Id))
                .ForMember(uesrVm => uesrVm.DateCreate,
                  opt => opt.MapFrom(user => user.DateCreate))
                .ForMember(uesrVm => uesrVm.EndWorkTime,
                  opt => opt.MapFrom(user => user.EndWorkTime))
                .ForMember(uesrVm => uesrVm.StartWorkTime,
                  opt => opt.MapFrom(user => user.StartWorkTime))
                .ForMember(uesrVm => uesrVm.CheckPhrase,
                  opt => opt.MapFrom(user => user.CheckPhrase))
                .ForMember(uesrVm => uesrVm.Email,
                  opt => opt.MapFrom(user => user.Email))
                .ForMember(uesrVm => uesrVm.Family,
                  opt => opt.MapFrom(user => user.Family))
                .ForMember(uesrVm => uesrVm.IdRole,
                  opt => opt.MapFrom(user => user.IdRole))
                .ForMember(uesrVm => uesrVm.Login,
                  opt => opt.MapFrom(user => user.Login))
                .ForMember(uesrVm => uesrVm.Name,
                  opt => opt.MapFrom(user => user.Name))
                .ForMember(uesrVm => uesrVm.Password,
                  opt => opt.MapFrom(user => user.Password))
                .ForMember(uesrVm => uesrVm.Patronymic,
                  opt => opt.MapFrom(user => user.Patronymic))
                .ForMember(uesrVm => uesrVm.PhotoImage,
                  opt => opt.MapFrom(user => user.PhotoImage));
                
        }
    }
}
