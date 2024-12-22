using BisnesManager.DatabasePersistens;
using BisnesManager.DatabasePersistens.Context;
using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Exception;
using BisnesManager.RequestsApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands
{
    public class ImplementBase<T> : ICommandInterafce<T> where T : class 
    {
        protected readonly BissnesExpertSystemDiplomaContext context;

        public ImplementBase(BissnesExpertSystemDiplomaContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var toDelete = await context.Set<T>().FindAsync(id);

            if (toDelete == null)
            {
                throw new NotFoundException(nameof(toDelete), id);
            }
            context.Set<T>().Remove(toDelete);
        }


        //public IEnumerable<V> GetByCondition(Func<T, bool> condition)
        //{
        //    var resultList = context.Set<T>().AsNoTracking().Where(condition).ToList();
        //    return resultList; //сделать преобразование
        //}

        //public Task<V> GetByIdAsync(int id)
        //{
        //    var result = context.Set<T>().FindAsync(id);
        //    return result; //сделать преобразвание
        //}

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }

        //public Task<V> SearchEntryByConditionAsync(Expression<Func<T, bool>> condition)
        //{
        //    var entry = context.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        //    return entry; //сделать преобразование
        //}
    }
}
