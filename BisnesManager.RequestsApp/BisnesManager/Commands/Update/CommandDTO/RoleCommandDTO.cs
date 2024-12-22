using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Update.CommandDTO
{
    public class RoleCommandDTO : IRequest
    {

        public short Id { get; set; }
        public string Title { get; set; } = null!;

        public bool IsEditWorkersRoles { get; set; }

        public bool IsEditWorkTimeTable { get; set; }

        public string? Post { get; set; }
    }
}
