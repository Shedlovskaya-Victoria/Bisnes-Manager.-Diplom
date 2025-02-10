using BisnesManager.Database.Context;
using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Database.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public RoleRepository(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }

        public Task<List<Role>> GetAllAsync()
        {
            return _context.Roles.ToListAsync();
        }
    }
}
