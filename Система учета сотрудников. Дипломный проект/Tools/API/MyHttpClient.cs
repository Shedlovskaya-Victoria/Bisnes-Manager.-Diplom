﻿
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
using System.Windows;
using System.Windows.Controls;

namespace Система_учета_сотрудников._Дипломный_проект.Tools.API
{
    public static class MyHttpClient
    {
        static HttpClient httpClient = new HttpClient();
        public static HttpClient GetHttpClient() 
        {
            return httpClient;
        }
        public static async Task<(string, UserDTO)> Auth(string login, PasswordBox password)
        {
            try
            {
                httpClient.BaseAddress = new Uri("http://localhost:5000/api/");

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return (SystemMessages.BadAuth, null);
            }
            
        }
        static void SetToken(string token)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        }
    }
}
