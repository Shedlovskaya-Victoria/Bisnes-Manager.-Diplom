using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class StatusMapper
    {
        public static StatusDTO ToStatusDTO(this Status status)
        {
            return new StatusDTO
            {
                Title = status.Title,
            };
        } 
    }
}
