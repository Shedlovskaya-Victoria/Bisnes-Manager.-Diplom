using BisnesManager.Database.Models;
using BisnesManager.ETL.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Interfaces
{
    interface IAuthRepository
    {
        public Task<User> FindUser(AuthDataDto authDataDto);
    }
}
