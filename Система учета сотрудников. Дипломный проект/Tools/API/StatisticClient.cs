using BisnesManager.ETL.update_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public class StatisticClient
    {
        internal static async Task<IEnumerable<UpdateStatisticDto>> GetAll()
        {
            return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<UpdateStatisticDto>>("Statistics/getAll");
        }
    }
}
