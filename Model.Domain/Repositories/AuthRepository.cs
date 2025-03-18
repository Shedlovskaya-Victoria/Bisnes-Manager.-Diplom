using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Models;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.Interfaces;
using BisnesManager.WebAPI.Diplom.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class AuthRepository : BaseRepository<string, AuthDataDto>, IAuthRepository
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public AuthRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }

        public async Task<User> FindUser(AuthDataDto authDataDto)
        {
            return _context.Users.FirstOrDefault(s=>s.Login ==  authDataDto.Login) ;
        }


        public override Task<string?> UpdateAsync(int id, AuthDataDto model)
        {
            throw new NotImplementedException();
        }
    }
}
