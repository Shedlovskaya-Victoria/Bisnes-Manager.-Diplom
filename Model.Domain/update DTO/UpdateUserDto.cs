using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.update_DTO
{
    public class UpdateUserDto
    {
        public string Name { get; set; } = null!;

        public string Family { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string CheckPhrase { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Login { get; set; } = null!;

        public short IdRole { get; set; }

        public short? WorkTimeCount { get; set; }

        public DateTime DateCreate { get; set; }

    }
}
