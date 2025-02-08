using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.request_DTO
{
    public class UserDtoRequest
    {
        public string Name { get; set; } = null!;

        public string Family { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CheckPhrase { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Login { get; set; } = null!;

        public short IdRole { get; set; }

        public byte[]? PhotoImage { get; set; }

        public DateTime StartWorkTime { get; set; }

        public DateTime EndWorkTime { get; set; }
    }
}
