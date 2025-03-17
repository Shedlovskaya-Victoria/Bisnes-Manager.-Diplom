using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
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
                Id = status.Id,
                Title = status.Title,
            };
        }
        public static Status ToStatus(this StatusDtoRequest dtoRequest)
        {
            return new Status
            {
                Title = dtoRequest.Title
            };
        }
    }
}
