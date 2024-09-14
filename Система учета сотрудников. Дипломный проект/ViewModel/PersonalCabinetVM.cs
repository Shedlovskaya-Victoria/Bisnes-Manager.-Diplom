using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.View;

namespace Система_учета_сотрудников._Дипломный_проект.ViewModel
{
    class PersonalCabinetVM
    {

        public Command Back { get; set; }
        public Command ChangePhoto { get; set; }
        public Command ChangeEmail { get; set; }
        public Command ChangeLogin { get; set; }
        public Command ChangePassword { get; set; }
        public Command SaveAll { get; set; }
        public Command DeleteAll { get; set; }

        public PersonalCabinetVM()
        {
            Back = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Home();
            }, () =>
            {
                return true;
            });
            ChangePhoto = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
            ChangeEmail = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
            ChangeLogin = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
            ChangePassword = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
            SaveAll = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
            DeleteAll = new Command(
            () =>
            {
            }, () =>
            {
                return true;
            });
        }
    }
}
