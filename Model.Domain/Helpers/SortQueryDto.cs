using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Helpers
{
    public class SortQueryDto          //request dto for sort user by family
    {
        public string SortBy { get; set; } = "";  //FAMILY
        public bool IsDecsending = false; //Убывает
    }
}
