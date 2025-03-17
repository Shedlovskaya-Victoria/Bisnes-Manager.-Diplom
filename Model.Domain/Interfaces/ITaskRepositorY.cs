using BisnesManager.Database.Model;
using BisnesManager.ETL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Interfaces
{
    public interface ITaskRepository
    {
        Task<IList<BisnesTask>?> GetAllAsync(FilterDateAndPaginateQueryDto query);

    }
}
