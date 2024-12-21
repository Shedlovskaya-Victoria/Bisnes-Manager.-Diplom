using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Domain.DTO
{
    public class Role
    {
        public short Id { get; set; }

        public string Title { get; set; } = null!;

        public bool IsEditWorkersRoles { get; set; }

        public bool IsEditWorkTimeTable { get; set; }

        public string? Post { get; set; }
    }
}
