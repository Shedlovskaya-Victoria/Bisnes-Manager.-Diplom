using BisnesManager.Database.Model;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class UserRepository : BaseRepository<User, UpdateUserDto>
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public UserRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context; 
        }

        public override async Task<User?> UpdateAsync(int id, UpdateUserDto model)
        {
            if (model == null) return null;

            var user = await _context.Users.Include(s => s.IdRoleNavigation).FirstOrDefaultAsync(s=>s.Id == id);

            if(user == null) return null;

            user.Login = model.Login;
            user.Password = model.Password;
            user.Email = model.Email;
            user.CheckPhrase = model.CheckPhrase;
            user.IdRole = model.IdRole;
            user.DateCreate = DateOnly.FromDateTime(model.DateCreate);
            user.EndWorkTime = DateOnly.FromDateTime(model.EndWorkTime);
            user.Family = model.Family;
            user.Name = model.Name;
            user.Patronymic = model.Patronymic;
            user.PhotoImage = model.PhotoImage;
            user.StartWorkTime = DateOnly.FromDateTime(model.StartWorkTime);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
