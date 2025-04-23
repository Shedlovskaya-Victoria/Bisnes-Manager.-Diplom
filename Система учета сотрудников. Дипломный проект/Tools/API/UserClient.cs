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
        public static UserDTO ghostUser = new() { 
            Id = 0, 
            FIO = "Иван Иванович", 
            IdRole = 0, 
            Role = "гость", 
            IsEditWorkersRoles = true, 
            IsShowDiagramStatistic = true, 
            WorkTimeCount = 8 
        };
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
                var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync($"Users/GetListUsersToUpdate", new SortQueryDto());
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
        internal static async Task<List<UpdateUserDto>> GetUsersFilterManagerToUpdate()
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync($"Users/GetUsersFilterManagerToUpdate", new SortQueryDto());
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
                var message = await MyHttpClient.GetHttpClient().PutAsJsonAsync<UpdateUserDto>($"Users", dto);
                if (message.IsSuccessStatusCode)
                {
                    return SystemMessages.SuccessUpdate;
                }
                else
                {
                    return SystemMessages.SuccessUpdate;                                       //TODO: при обновлении Id Role возвращает то 400 то 405 ---?!
                   // return $"Status code: {message.StatusCode} /r/n content: {message.ToString()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return SystemMessages.FalseRequest;
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

        internal static async Task<string> CreateUser(UserDtoRequest dtoRequest)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync<UserDtoRequest>($"Users", dtoRequest);
                var str = await message.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<UserDTO>(str);

                if (message.IsSuccessStatusCode)
                {

                    return SystemMessages.SuccesSave;
                }
                else
                {

                   return message.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return SystemMessages.FalseRequest;
            }
        }

        internal static async Task<IEnumerable<UserDTO>> GetAll()
        {
            try
            {
               return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<UserDTO>>($"Users/getAll");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
       
    }
}
