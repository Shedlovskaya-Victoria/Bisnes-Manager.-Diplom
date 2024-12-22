using AutoMapper;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetDetails.StatisticDetails
{
    public class StatisticVm : IMapWith<Statistic>
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

        public int QualityWork { get; set; }

        public int LevelResponibility { get; set; }

        public int EffectivCommunication { get; set; }

        public int HardSkils { get; set; }

        public int SoftSkils { get; set; }

        public DateOnly DateCreate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Statistic, StatisticVm>()
                .ForMember(statVm => statVm.Id,
                  opt => opt.MapFrom(stat => stat.Id))
                .ForMember(statVm => statVm.QualityWork,
                  opt => opt.MapFrom(stat => stat.QualityWork))
                .ForMember(statVm => statVm.DateCreate,
                  opt => opt.MapFrom(stat => stat.DateCreate))
                .ForMember(statVm => statVm.EffectivCommunication,
                  opt => opt.MapFrom(stat => stat.EffectivCommunication))
                .ForMember(statVm => statVm.HardSkils,
                  opt => opt.MapFrom(stat => stat.HardSkils))
                .ForMember(statVm => statVm.LevelResponibility,
                  opt => opt.MapFrom(stat => stat.LevelResponibility))
                .ForMember(statVm => statVm.SoftSkils,
                  opt => opt.MapFrom(stat => stat.SoftSkils))
                .ForMember(statVm => statVm.IdUser,
                  opt => opt.MapFrom(stat => stat.IdUser));

        }
    }
}
