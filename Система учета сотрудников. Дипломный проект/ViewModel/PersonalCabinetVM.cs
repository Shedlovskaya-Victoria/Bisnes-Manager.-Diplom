using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.ETL.DTO;

namespace BisnesManager.Client.ViewModel
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
        public PersonalCabinetVM() { }
        public PersonalCabinetVM(UserDTO user)
        {
            Back = new Command(
            () =>
            {
                Navigation.Instance().CurrentPage = new Home(user);
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
