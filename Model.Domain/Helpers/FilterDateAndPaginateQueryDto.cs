using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Helpers
{
    public class FilterDateAndPaginateQueryDto          //request dto for filter statistic and task by date
    {
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 1;
    }
}
 