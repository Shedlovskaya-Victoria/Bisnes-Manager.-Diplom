using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.DTO
{
    public class RoleDTO
    {
        public short Id { get; set; }
        public string Title { get; set; } = null!;

        public bool IsEditWorkersRoles { get; set; }

        public bool IsShowDiagramStatistic { get; set; }

        public string? Post { get; set; }

        public bool? IsUse { get; set; }
    }
}
