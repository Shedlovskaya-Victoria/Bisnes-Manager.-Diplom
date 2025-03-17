using BisnesManager.Database.Models;
using BisnesManager.ETL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>?> GetAllAsync(SortQueryDto query);

    }
}
