using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.request_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public class TaskClient
    {
        const int AdminPageSize = 100;
        public static bool IsUsePlaneStatus = true, IsUseWorkStatus = true, IsUseEndStatus = true, IsUseArchiveStatus = true;

        public static async Task<IEnumerable<BisnesTaskDTO>> GetAllTasks()
        {
           var answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?PageSize={AdminPageSize}" );
         
            if (answ != null)
            {
                return answ;
            }
            else
            {
                return null;
            }

        }

        internal static async Task<IEnumerable<BisnesTaskDTO>> GetUsersTasks(int userId)
        {
            try
            {
                return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks/{userId}");

            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString());
                return null;
            }

        }
    }
}
