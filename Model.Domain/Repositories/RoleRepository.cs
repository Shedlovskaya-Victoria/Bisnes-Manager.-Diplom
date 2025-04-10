using BisnesManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.ETL;
using BisnesManager.ETL.update_DTO;
using BisnesManager.ETL.Mapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;

namespace BisnesManager.Database.Repositories
{
    public class RoleRepository : BaseRepository<UserRole, UpdateRoleDto>
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public RoleRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserRole>> GetAllFilterIsUseAsync()
        {
            return await _context.UserRoles.Where(s=>s.IsUse==true).ToListAsync();
        }
        public async Task<IEnumerable<UserRole>> GetRolesFilterManagerAsync()
        {

            return await _context.UserRoles.Where(s => s.IsUse == true & s.Id!=1).ToListAsync();
        }
        public async override Task<UserRole?> UpdateAsync(int id, UpdateRoleDto model)
        {
            if (model == null) return null;
            if (id == 0) return null;

            var role = await _context.UserRoles.FirstOrDefaultAsync(s=>s.Id == id);

            if (role == null) return null;

            role.Title = model.Title;
            role.DateCreate = DateOnly.FromDateTime(model.DateCreate);
            role.IsEditWorkersRoles = model.IsEditWorkersRoles;
            role.IsShowDiagramStatistic = model.IsShowDiagramStatistic;
            role.Post = model.Post;
            role.IsUse = model.IsUse;

            await _context.SaveChangesAsync();

            return role;
        }
       
    }
}
