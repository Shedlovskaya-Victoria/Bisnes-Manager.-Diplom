using BisnesManager.Database.Interfaces;
using BisnesManager.Database.Models;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class PlanRepository : BaseRepository<HolidayPlan, UpdatePlanDto>
    {
        private readonly BissnesExpertSystemDiploma7Context _context;
        public PlanRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<HolidayPlan?> UpdateAsync(int id, UpdatePlanDto model)
        {
            if (model == null) return null;
            if (id == 0) return null;

            var plan = await _context.HolidayPlans.FirstOrDefaultAsync(s=>s.Id == id);

            if(plan == null) return null;

            plan.StartWeekends = DateOnly.FromDateTime(model.StartWeekends);
            plan.DateCreate = DateOnly.FromDateTime(model.DateCreate);
            plan.EndWeekends = DateOnly.FromDateTime(model.EndWeekends);
            plan.IdUser = model.IdUser;

            await _context.SaveChangesAsync();
            return plan;
        }
    }
}
