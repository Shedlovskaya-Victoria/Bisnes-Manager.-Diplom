
using BisnesManager.ETL.Auth;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public static class MyHttpClient
    {
        static HttpClient httpClient = new HttpClient();
        public static async Task<(string, UserDTO)> Auth(string login, PasswordBox password)
        {
            httpClient.BaseAddress = new Uri("https://localhost:7285/api/");

            HttpResponseMessage message; AuthDtoRequest response;
           
            message = await httpClient.PostAsJsonAsync($"Auth/Authorizate", new AuthDataDto { Login = login, Password = password.Password });
            var str = await message.Content.ReadAsStringAsync();
            response = JsonSerializer.Deserialize<AuthDtoRequest>(str);
           
            if (message.IsSuccessStatusCode)
            {
                SetToken(response.Token);
                return (SystemMessages.SuccessAuth, response.User);
            }
            else
            {
                return ($"Status code: {message.StatusCode} /r/n content: {str}", null);
            }

            
        }
        static void SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }
    }
}
