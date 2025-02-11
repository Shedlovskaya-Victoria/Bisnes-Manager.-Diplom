using BisnesManager.Database.Model;
using BisnesManager.Database.Repositories;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Repositories
{
    public class StatusRepository : BaseRepository<Status, UpdateStatusDto>
    {
        private readonly BissnesExpertSystemDiploma7Context _context;

        public StatusRepository(BissnesExpertSystemDiploma7Context context) : base(context)
        {
            _context = context;
        }

        public override async Task<Status?> UpdateAsync(int id, UpdateStatusDto model)
        {
            if (model == null) return null;

            var status = await _context.Statuses.FirstOrDefaultAsync(s=>s.Id == id);

            if(status == null) return null;

            status.Title = model.Title;
            await _context.SaveChangesAsync();

            return status;
        }
    }
}
