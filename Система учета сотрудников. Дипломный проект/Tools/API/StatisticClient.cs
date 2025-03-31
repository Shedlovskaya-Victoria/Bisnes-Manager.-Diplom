using BisnesManager.ETL.DTO;
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
    public class StatisticClient
    {
        internal static async Task<IEnumerable<UpdateStatisticDto>> GetAll()
        {
            return await MyHttpClient.GetHttpClient().GetFromJsonAsync<IEnumerable<UpdateStatisticDto>>("Statistics/getAll");
        }
        internal static async Task<string> Create(StatisticDtoRequest statistic)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PostAsJsonAsync<StatisticDtoRequest>($"Statistics/Create", statistic);
                var str = await message.Content.ReadAsStringAsync();
                var response = JsonSerializer.Deserialize<StatisticDTO>(str);

                if (message.IsSuccessStatusCode)
                {

                    return SystemMessages.SuccesSave;
                }
                else
                {

                    return message.Content.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return SystemMessages.FalseRequest;
            }
        }
        internal static async Task<string> Update(UpdateStatisticDto updateStatistic)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().PutAsJsonAsync<UpdateStatisticDto>($"Statistics/{updateStatistic.Id}", updateStatistic);
                if (message.IsSuccessStatusCode)
                {
                    return SystemMessages.SuccessUpdate;
                }
                else
                {
                    //return SystemMessages.SuccessUpdate;                         //TODO: при обновлении Id Role возвращает то 400 то 405 ---?!
                    return $"Status code: {message.StatusCode} /r/n content: {message.ToString()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return SystemMessages.FalseRequest;
            }
        }
        internal static async Task<string> Delete(int id)
        {
            try
            {
                var message = await MyHttpClient.GetHttpClient().DeleteAsync($"Statistics/{id}");
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
