using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO
{
    public class UserUpdateCommandDTO : IRequest
    {

        public short Id { get; set; }
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

        public DateTimeOffset EndWorkTime { get; set; }

        public DateOnly DateCreate { get; set; }
    }
}
