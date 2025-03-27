using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Helpers;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
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
    public class UserClient
    {
        public static UserDTO user;
        internal static async Task<UpdateUserDto> GetUserByIdToUpdate(int id)
        {
            try
            {
                var a = await MyHttpClient.GetHttpClient().GetFromJsonAsync<UpdateUserDto>($"Users/{id}");
                return a;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        internal static async Task<List<UpdateUserDto>> GetListUsersToUpdate()
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync($"Users/GetAll", new SortQueryDto());
                var str = await message.Content.ReadAsStringAsync();
               var response = JsonSerializer.Deserialize<List<UpdateUserDto>>(str);

                if (message.IsSuccessStatusCode)
                {

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        internal static async Task<string> UpdateUser(UpdateUserDto dto)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PutAsJsonAsync<UpdateUserDto>($"Users/{UserClient.user.Id}", dto);
                if (message.IsSuccessStatusCode)
                {
                    return SystemMessages.SuccessUpdate;
                }
                else
                {
                    return $"Status code: {message.StatusCode} /r/n content: {message.Content}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        internal static async Task<string> DeleteUser(int id)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().DeleteAsync($"Users/{id}");
                if (message.IsSuccessStatusCode)
                {
                    return SystemMessages.SuccessDelete;
                }
                else
                {
                    return $"Status code: {message.StatusCode} /r/n content: {message.Content}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
