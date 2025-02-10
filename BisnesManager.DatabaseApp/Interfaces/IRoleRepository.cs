using BisnesManager.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Database.Interfaces
{
    public interface IRoleRepository
    {
         Task<List<Role>> GetAllAsync();
    }
}
