using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
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
                Id = statistic.Id,
                DateCreate = statistic.DateCreate,
                SoftSkils = statistic.SoftSkils,
                HardSkils = statistic.HardSkils,    
                LevelResponibility = statistic.LevelResponibility,  
                QualityWork = statistic.QualityWork,    
            };
        }
        public static UpdateStatisticDto ToUpdateDTO(this Statistic statistic)
        {
            return new UpdateStatisticDto
            {
                Id = statistic.Id,
                IdUser = statistic.IdUser,
                DateCreate = DateTime.Parse(statistic.DateCreate.ToString()),
                SoftSkils = statistic.SoftSkils,
                HardSkils = statistic.HardSkils,    
                LevelResponibility = statistic.LevelResponibility,  
                QualityWork = statistic.QualityWork,    
            };
        }
        public static Statistic ToStatisticFromCreateDTO(this StatisticDtoRequest dtoRequest)
        {
            return new Statistic
            {
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                QualityWork = dtoRequest.QualityWork,
                HardSkils= dtoRequest.HardSkils,    
                LevelResponibility= dtoRequest.LevelResponibility,
                SoftSkils= dtoRequest.SoftSkils,
                IdUser= dtoRequest.IdUser,
                
            };
        }
        public static StatisticDtoRequest ToDtoCreateFromUpdateDTO(this UpdateStatisticDto dtoRequest)
        {
            return new StatisticDtoRequest
            {
                
                QualityWork = dtoRequest.QualityWork,
                HardSkils= dtoRequest.HardSkils,    
                LevelResponibility= dtoRequest.LevelResponibility,
                SoftSkils= dtoRequest.SoftSkils,
                IdUser= dtoRequest.IdUser,
                
            };
        }
    }
}
