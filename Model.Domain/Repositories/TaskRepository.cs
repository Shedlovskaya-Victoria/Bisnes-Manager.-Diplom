using BisnesManager.Database.Models;
using BisnesManager.Database.Repositories;
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
    public class TaskRepository : BaseRepository<BisnesTask, UpdateTaskDto>, ITaskRepository
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public TaskRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }

        public async Task<IList<BisnesTask>?> GetAllAsync(FilterDateAndPaginateQueryDto query)
        {
            var list = _context.BisnesTasks.Include(s => s.IdUserNavigation).AsQueryable();

            if (query.dateStart != DateTime.Parse("01.01.0001"))
            {
                list = list.Where(s => s.DateCreate >= DateOnly.FromDateTime(query.dateStart.Date));
            }
            if (query.dateEnd != DateTime.Parse("01.01.0001"))
            {
                list = list.Where(s => s.DateCreate <= DateOnly.FromDateTime(query.dateEnd));
            }

            if (query.PageSize > 2)
            {
                var skipNumber = (query.PageNumber - 1) * query.PageSize;
                return await list.Skip(skipNumber).Take(query.PageSize).ToListAsync();
            }
            return await list.ToListAsync();
        }

        public override async Task<BisnesTask?> UpdateAsync(int id, UpdateTaskDto model)
        {
            if (model == null) return null;

            var task = await _context.BisnesTasks
                .Include(s => s.IdStatusNavigation)
                .Include(s => s.IdUserNavigation)
                .FirstOrDefaultAsync(s=>s.Id == id);

            if (task == null) return null;

            task.StartDate = DateOnly.FromDateTime(model.StartDate);
            task.DateCreate = DateOnly.FromDateTime(model.DateCreate);
            task.IdUser = model.IdUser;
            task.EndDate = DateOnly.FromDateTime(model.EndDate);
            task.Indentation = model.Indentation;
            task.AssignmentsContent = model.AssignmentsContent;
            task.IdStatus = model.IdStatus;
            task.Content = model.Content;

            await _context.SaveChangesAsync();
            return task;
        }
    }
}
