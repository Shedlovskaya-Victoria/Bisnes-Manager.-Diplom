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
using Система_учета_сотрудников._Дипломный_проект.Tools;
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
            SaveAll = new Command(async () =>
            {
                string answ;
                if(UserClient.ghostUser.IdRole != updateUserDto.IdRole)
                {
                   answ = await UserClient.UpdateUser(User);
                }
                else
                {
                    UserClient.ghostUser.FIO = $"{User.Name} {User.Family} {User.Patronymic}";
                    UserClient.user = UserClient.ghostUser;
                    answ = SystemMessages.SuccessUpdate;
                }

                CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
            }, () =>
            {
                return true;
            });
            DeleteAll = new Command(async () =>
            {
                string answ;
                if(UserClient.ghostUser.IdRole != User.IdRole)
                {
                   answ = await UserClient.DeleteUser(User.Id);
                }
                else
                {
                    answ = SystemMessages.SuccessDelete;
                }
                CheckResultAndGo(answ, SystemMessages.SuccessDelete);
            }, () =>
            {
                return true;
            });
        }

            

    }
}
