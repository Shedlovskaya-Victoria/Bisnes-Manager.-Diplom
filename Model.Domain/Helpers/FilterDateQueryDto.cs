using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Helpers
{
    public class FilterDateQueryDto          //request dto for filter statistic and task by date
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        
             
    }
}
