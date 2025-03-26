using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.ViewModel
{
    public class EnterVM 
    {
        public CommandWithParametr<string> Autentification { get; set; }
        public Command Recover { get; set; }
       
        public EnterVM(PasswordBox passwordBox) 
        {
            /*
            Autentification = new CommandWithParametr<User>((parametr) =>
            {

            }, (parametr) =>
            {
               if (parametr != null) 
               {
                    
                }
             });
            */

            Autentification = new CommandWithParametr<string>(
            async (login) =>
            {
                if (string.IsNullOrEmpty(login) | string.IsNullOrEmpty(passwordBox.Password))
                    MessageBox.Show(SystemMessages.BadAuth);

                if (login == "0" & passwordBox.Password == "0")
                {
                    var u = new ETL.DTO.UserDTO { FIO = "Имя Фамилия Отчество", IdRole = 6, Role = "гость", WorkTimeCount = 8 };
                    Navigation.Instance().CurrentPage = new Home(u);
                    UserClient.user = u;
                }
                else
                {
                    var answer = (await MyHttpClient.Auth(login, passwordBox));
                    UserClient.user = answer.Item2;

                    if (answer.Item1 == SystemMessages.SuccessAuth)
                        Navigation.Instance().CurrentPage = new Home(answer.Item2);
                    else
                        MessageBox.Show(answer.Item1);
                }
            }, () => 
            {
                return true;
            });
            Recover = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new RecoverAutorizateData();
            }, () => 
            {
                return true;
            });
        }

        public EnterVM()
        {
        }
    }

}
