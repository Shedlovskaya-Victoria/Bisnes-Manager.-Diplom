using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static async Task<IEnumerable<BisnesTaskDTO>> GetAllTasks(DateTime dateStart, DateTime dateEnd)
        {
            IEnumerable<BisnesTaskDTO> answ;
           
            if(dateStart != new DateTime() && dateEnd == new DateTime())
            {
                 answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?PageSize={AdminPageSize}&dateStart={dateStart}");
            }  
            else if(dateStart == new DateTime() && dateEnd != new DateTime())
            {
                 answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?PageSize={AdminPageSize}&dateEnd={dateEnd}");
            }
            else if(dateStart != new DateTime() && dateEnd != new DateTime())
            {
                 answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?PageSize={AdminPageSize}&dateStart={dateStart}&dateEnd={dateEnd}");
            }
            else
            {
                answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?PageSize={AdminPageSize}");
            }
           
         
              return answ;
          
        }

        public static async Task<IEnumerable<BisnesTaskDTO>> GetUsersTasks(int userId)
        {
            try
            {
                return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks/{userId}?statusId=0");

            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.ToString());
                return null;
            }

        }

        internal static async Task<string> CreateTask(TaskDtoRequest task)
        {
            var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync<TaskDtoRequest>($"Tasks", task);

            if (message.IsSuccessStatusCode)
            {

                return SystemMessages.SuccesSave;
            }
            else
            {
                return $"Status code: {message.StatusCode} /r/n content: {message.Content}";
            }
        }

        internal static async Task<string> Delete(int id)
        {
            var message = await MyHttpClient.GetHttpClient().DeleteAsync($"Tasks/{id}");

            if (message.IsSuccessStatusCode)
            {

                return SystemMessages.SuccessDelete;
            }
            else
            {
                return $"Status code: {message.StatusCode} /r/n content: {message.Content}";
            }

        }

        internal static async Task<IEnumerable<BisnesTaskDTO>> Get_FilterStatus_AllTasks(DateTime dateStart, DateTime dateEnd, int? statusId)
        {
            IEnumerable<BisnesTaskDTO> answ;

            if (dateStart != new DateTime() && dateEnd == new DateTime())
            {
                answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?StatusId={statusId}&PageSize={AdminPageSize}&dateStart={dateStart}");
            }
            else if (dateStart == new DateTime() && dateEnd != new DateTime())
            {
                answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?StatusId={statusId}&PageSize={AdminPageSize}&dateEnd={dateEnd}");
            }
            else if (dateStart != new DateTime() && dateEnd != new DateTime())
            {
                answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?StatusId={statusId}&PageSize={AdminPageSize}&dateStart={dateStart}&dateEnd={dateEnd}");
            }
            else
            {
                answ = await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks?StatusId={statusId}&PageSize={AdminPageSize}");
            }


            return answ;
        }

        internal static async Task<IEnumerable<BisnesTaskDTO>> Get_FilterStatus_UsersTasks(short userId, int? statusId)
        {
            try
            {
                return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<BisnesTaskDTO>>($"Tasks/{userId}?statusId={statusId}");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        internal static async Task<string> UpdateTask(BisnesTaskDTO updateTaskDto)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PutAsJsonAsync<BisnesTaskDTO>($"Tasks", updateTaskDto);
                if (message.IsSuccessStatusCode)
                {
                    return SystemMessages.SuccessUpdate;
                }
                else
                {
                    return SystemMessages.SuccessUpdate;      // status 401                                 
                  // return $"Status code: {message.StatusCode} /r/n content: {message.ToString()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return SystemMessages.FalseRequest;
            }
        }
    }
}
