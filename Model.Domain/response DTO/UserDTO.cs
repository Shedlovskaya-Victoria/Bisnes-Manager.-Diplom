using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.DTO
{
    public class UserDTO
    {
        public short Id { get; set; }
        public string FIO { get; set; } = null!;

        public short? IdRole { get; set; }
        public string? Role { get; set; }
        public bool IsEditWorkersRoles { get; set; }

        public bool IsShowDiagramStatistic { get; set; }

        public short? WorkTimeCount { get; set; }


    }
}
