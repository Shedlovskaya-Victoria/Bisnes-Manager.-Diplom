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

        public string? Role { get; set; }

        public byte[]? PhotoImage { get; set; }

        public DateTime? StartWorkTime { get; set; }

        public DateTime? EndWorkTime { get; set; } = null;

    }
}
