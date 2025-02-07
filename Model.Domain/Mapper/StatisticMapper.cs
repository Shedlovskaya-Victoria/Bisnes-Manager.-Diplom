using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class StatisticMapper
    {
        public static StatisticDTO ToStatisticDTO(this Statistic statistic)
        {
            return new StatisticDTO
            {
                DateCreate = statistic.DateCreate,
                SoftSkils = statistic.SoftSkils,
                HardSkils = statistic.HardSkils,    
                EffectivCommunication = statistic.EffectivCommunication,
                LevelResponibility = statistic.LevelResponibility,  
                QualityWork = statistic.QualityWork,    
            };
        }
    }
}
