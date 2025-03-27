using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.update_DTO
{
    public class UpdateRoleDto
    {
        public string Title { get; set; } = null!;

        public bool IsEditWorkersRoles { get; set; }

        public bool IsEditWorkTimeTable { get; set; }

        public string? Post { get; set; }

        public DateTime DateCreate { get; set; }

        public bool? IsUse { get; set; }
    }
}
