using BisnesManager.Database.Models;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.Interfaces;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class StatisticRepository : BaseRepository<Statistic, UpdateStatisticDto>, IStatisticRepository
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public StatisticRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }
        public async Task<IList<Statistic>?> GetAllAsync(FilterDateAndPaginateQueryDto query)
        {
            var statistics = _context.Statistics.AsQueryable();
            if(query.dateStart != DateTime.Parse("01.01.0001") )
            {
                statistics = statistics.Where(s => s.DateCreate >= DateOnly.FromDateTime(query.dateStart.Date));
            }
            if(query.dateEnd != DateTime.Parse("01.01.0001"))
            {
                statistics = statistics.Where(s => s.DateCreate <= DateOnly.FromDateTime(query.dateEnd));
            }
            
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await statistics.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<IList<Statistic>?> GetAllByIdAsync(int UserId)
        {
            return await _context.Statistics.Where(s=>s.IdUser == UserId).ToListAsync();
        }

        public override async Task<Statistic?> UpdateAsync(int id, UpdateStatisticDto model)
        {
            if (model == null) return null;
            if (id == 0) return null;

            var statistic = await _context.Statistics.FirstOrDefaultAsync(x => x.Id == id);

            if (statistic == null) return null;

            statistic.QualityWork = model.QualityWork;
            statistic.DateCreate = DateOnly.FromDateTime(model.DateCreate);
            statistic.HardSkils = model.HardSkils;
            statistic.SoftSkils = model.SoftSkils;
            statistic.LevelResponibility = model.LevelResponibility;
            statistic.IdUser = model.IdUser;

            await _context.SaveChangesAsync();

            return statistic;
        }

    }
}
