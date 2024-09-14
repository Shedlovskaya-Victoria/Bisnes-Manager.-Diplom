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
    public class RegistrationVM
    {
        public Command Registration { get; set; }
        public Command Back { get; set; }

        public RegistrationVM() 
        {
            Registration = new Command(
            () =>
            { 

            }, () => 
            { 
                return true; 
            });
            Back = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Enter();
            }, () => 
            { 
                return true; 
            });
        }
    }
}
