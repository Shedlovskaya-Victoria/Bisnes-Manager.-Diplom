using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.Interfaces
{
    public interface ICommandInterafce<T> where T : class 
    {
       // Task<T> GetByIdAsync(int id);
        //IEnumerable<V> GetByCondition(Func<T, bool> condition);
       // Task<V> SearchEntryByConditionAsync(Expression<Func<T, bool>> condition);
        Task DeleteAsync(int id);
        Task SaveAsync();
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
