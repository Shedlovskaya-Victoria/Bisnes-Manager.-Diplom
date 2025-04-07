using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public class StatusClient
    {
        public static async Task<IEnumerable<StatusDTO>> GetAll()
        {
            return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<StatusDTO>>("Statuses");
        }
    }
}
