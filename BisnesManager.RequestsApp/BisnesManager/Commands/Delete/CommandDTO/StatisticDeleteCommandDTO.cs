using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Commands.Delete.CommandDTO
{
    public class StatisticDeleteCommandDTO : IRequest
    {

        public int Id { get; set; }
        public short IdUser { get; set; }

    }
}
