using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatisticsList
{
    internal class StatisticsQuery : IRequest<StatisticsVm>
    {

        public short IdUser { get; set; }
    }
}
