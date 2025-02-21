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
    public abstract class BaseRepository<T, V> : IBaseRepository<T, V> where T : class where V : class
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public BaseRepository(BissnesExpertSystemDiploma7Context context)
        {
            _context = context;
        }

        public async Task<T?> CreateAsync(T model)
        {
            if (model == null) return null;

            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<T> DeleteAsync(int id)
        {
            if (id == 0)
                return null;

            var delete = await _context.Set<T>().FindAsync(id);

            if (delete == null)
                return null;

            _context.Set<T>().Remove(delete);
            await _context.SaveChangesAsync();

            return delete;
        }
        
        public async Task<T?> DeleteAsync(short id)
        {
            var delete = await _context.Set<T>().FindAsync(id);

            if (delete == null)
                return null;

            _context.Set<T>().Remove(delete);

            await _context.SaveChangesAsync();

            return delete;
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(short id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public abstract Task<T?> UpdateAsync(int id, V model);
    }
}
