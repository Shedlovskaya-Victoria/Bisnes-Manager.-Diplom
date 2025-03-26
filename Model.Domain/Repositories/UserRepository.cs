using BisnesManager.Database.Models;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.Interfaces;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class UserRepository : BaseRepository<User, UpdateUserDto>, IUserRepository
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public UserRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context; 
        }

        public async Task<IList<User>?> GetAllAsync(SortQueryDto query)
        {
            var list = _context.Users.Include(s => s.IdRoleNavigation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.ToUpper().Equals("FAMILY", StringComparison.CurrentCultureIgnoreCase))
                {
                    list = query.IsDecsending ? list.OrderByDescending(s => s.Family) : list.OrderBy(s => s.Family);
                }
            }

            return await list.ToListAsync();
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
        public async override Task<User> CreateAsync(User user)
        {

            if (user == null) throw new ArgumentNullException("User can't be null!");

            var IsExists =  _context.Users.FirstOrDefault(s => s.Login == user.Login) != null ? false : true;

            if(IsExists)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return _context.Users.Include(s=>s.IdRoleNavigation).FirstOrDefault(s => s.Login == user.Login); //чтобы для дто ответа включало роль
            }
            else
            {
                return null;
            }
        }
    }
}
