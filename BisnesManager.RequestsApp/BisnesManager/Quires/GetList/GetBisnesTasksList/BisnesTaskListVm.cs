using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.RequestsApp.BisnesManager.Quires.GetList.GetBisnesTasksList
{
    public class BisnesTaskListVm
    {
        public List<GetListBisnesTaskDto> BisnesTasks { get; set; } = new();
    }
}
