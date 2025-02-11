using BisnesManager.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Database.Interfaces
{
    public interface IBaseRepository<T, V> where T : class where V : class
    {
        Task<IEnumerable<T>?> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> CreateAsync(T model);
        Task<T?> UpdateAsync(int id, V model);
        Task<T?> DeleteAsync(int id);
    }
}
