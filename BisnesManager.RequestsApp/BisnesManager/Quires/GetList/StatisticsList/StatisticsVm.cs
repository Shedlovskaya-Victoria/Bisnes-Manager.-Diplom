using BisnesManager.DatabasePersistens.Model;
using BisnesManager.RequestsApp.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.StatisticsList
{
    internal class StatisticsVm 
    {
        public List<StatisticsListDto> Statistics { get; set; } 
    }
}
