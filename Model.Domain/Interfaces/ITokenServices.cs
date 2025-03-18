using BisnesManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Interfaces
{
    public interface ITokenServices
    {
        string CreateToken(User user);
    }
}
