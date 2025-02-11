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
    public class TaskRepository : BaseRepository<BisnesTask, UpdateTaskDto>
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public TaskRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
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
