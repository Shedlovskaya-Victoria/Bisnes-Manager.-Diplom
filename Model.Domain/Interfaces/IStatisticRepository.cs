using BisnesManager.Database.Models;
using BisnesManager.ETL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Interfaces
{
    public interface IStatisticRepository
    {
        Task<IList<Statistic>?> GetAllByIdAsync(int UserId);
        Task<IList<Statistic>?> GetAllAsync(FilterDateAndPaginateQueryDto query);

    }
}
