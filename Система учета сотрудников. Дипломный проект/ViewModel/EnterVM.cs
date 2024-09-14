using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.View;

namespace Система_учета_сотрудников._Дипломный_проект.ViewModel
{
    public class EnterVM
    {
       // public User User { get; set; }


       // public CommandWithParametr<User> Autentification { get; set; }
        public Command Autentification { get; set; }
        public Command Autorization { get; set; }
        public Command Recover { get; set; }
        public EnterVM()
        {
        }
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

            Autentification = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Home();
            }, () => 
            {
                return true;
            });
            Autorization = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Registrate();
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
    }
}
