using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public class RoleClient
    {
        public static async Task<List<UpdateRoleDto>> GetRolesList()
        {
            return await MyHttpClient.GetHttpClient().GetFromJsonAsync<List<UpdateRoleDto>>("Roles");
        }
        public static async Task<List<UpdateRoleDto>> GetAllFilterIsUse()
        {
            return await MyHttpClient.GetHttpClient().GetFromJsonAsync<List<UpdateRoleDto>>("Roles/GetAllFilterIsUse");
        }

        internal static async Task<string> UpdateRole(UpdateRoleDto selectedRole)
        {
          var message =  await MyHttpClient.GetHttpClient().PutAsJsonAsync($"Roles", selectedRole);

            if (message.IsSuccessStatusCode)
            {

                return SystemMessages.SuccesSave;
            }
            else
            {
                return message.Content.ToString();
            }
        }
    }
}
