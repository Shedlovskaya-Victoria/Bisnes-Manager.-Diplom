using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.View;

namespace Система_учета_сотрудников._Дипломный_проект.ViewModel
{
    public class RecoverVM
    {
        public Command Back {  get; set; }
        public Command UpdateAuthorizateData {  get; set; }

        public RecoverVM ()
        {
            Back = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Enter();
            }, () => 
            {
                return true;
            });
            UpdateAuthorizateData = new Command(
            () =>
            {
            }, () => 
            {
                return true;
            });
        }
    }
}
