using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.ViewModel
{
    class PersonalCabinetVM : Base
    {
        private UpdateUserDto user;

        public UpdateUserDto User
        {
            get => user;
            set { 
                user = value;
                Signal();
            }
        }

        public Command Back { get; set; }
        public Command SaveAll { get; set; }
        public Command DeleteAll { get; set; }
       
        public PersonalCabinetVM() { }
        public PersonalCabinetVM(UpdateUserDto updateUserDto)
        {
            User = updateUserDto;
            Back = new Command(() =>
            {
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
            }, () =>
            {
                return true;
            });
            SaveAll = new Command(() =>
            {
                UpdateUser(User);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
            }, () =>
            {
                return true;
            });
            DeleteAll = new Command(() =>
            {
                DeleteUser(UserClient.user.Id);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
            }, () =>
            {
                return true;
            });
        }

        private async Task DeleteUser(short id)
        {
            var answ = await UserClient.DeleteUser(id);
            MessageBox.Show(answ);
        }

        private async Task UpdateUser(UpdateUserDto user)
        {
            var answ = await UserClient.UpdateUser(user);
            MessageBox.Show(answ);
        }

    }
}
