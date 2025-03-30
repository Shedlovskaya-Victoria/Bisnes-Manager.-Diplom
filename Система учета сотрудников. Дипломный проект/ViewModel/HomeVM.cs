using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.Client.View.PageParts;
using BisnesManager.Client.View.Pages;
using BisnesManager.Client.View.ProgramUserControl;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using Microsoft.Extensions.Logging;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.ViewModel
{
    public class HomeVM
    {
        public Command Find {  get; set; }

        public Command GoToPersonalCabinet {  get; set; }
        public Command GoToHome {  get; set; }
      //  public Command GoToSystemSettings {  get; set; }
        public Command GoToAdministrationOffice {  get; set; }
       // public Command GoToUploadLists {  get; set; }

        public Command ShowKPDWorkers {  get; set; }
        public Command ShowWorkersKPDGraphiks {  get; set; }
        public Command ShowWorkersTimeTable {  get; set; }
        public Command ShowVisualPartsAllProjects {  get; set; }
        public Command ShowDiagramGant {  get; set; }

        public Command EditWorkers {  get; set; }
        public Command EditPosition {  get; set; }


        public string UserName { get; set; }

       

        public HomeVM() { }

        public HomeVM(ContentControl control, UserDTO user)
        {
            UserName = $"{user.Role}: {user.FIO}";

           
            Find = new Command(() =>
            {
               
            }, () =>
            {
                return true;
            });
            // go to
            GoToPersonalCabinet = new Command(async () =>
            {
                if (user.IdRole != 6)
                {
                   var userUpdate = await UserClient.GetUserByIdToUpdate(UserClient.user.Id);
                   userUpdate.Password = "";
                   Navigation.Instance().CurrentPage = new PersonalCabinet(userUpdate);
                }
                else 
                    Navigation.Instance().CurrentPage = new PersonalCabinet(new ETL.update_DTO.UpdateUserDto());
            }, () =>
            {
                return true;
            });
            GoToHome = new Command(async () =>
            {
                
                control.Content = new TasksBoard(user.IdRole, user.Id);
               
            }, () =>
            {
                return true;
            });
            // settings
            //GoToSystemSettings = new Command(() =>
            //{
            //    control.Content = new Settings();
            //}, () =>
            //{
            //    return true;
            //});
            //GoToUploadLists = new Command(() =>
            //{
            //}, () =>
            //{
            //    return true;
            //});
            //    show
            ShowKPDWorkers = new Command(() =>
            {
                control.Content = new KPDWorkers();
            }, () =>
            {
                return true;
            });
            ShowWorkersKPDGraphiks = new Command(() =>
            {
                control.Content = new Workers();
            }, () =>
            {
                return true;
            });
            ShowWorkersTimeTable = new Command(() =>
            {
                control.Content = new WorkersTimeTable();
            }, () =>
            {
                return true;
            });
            ShowVisualPartsAllProjects = new Command(async () =>
            {
              


                control.Content = new VisualPartsAllProjects(user.Id, user.IdRole);
            }, () =>
            {
                return true;
            });
            ShowDiagramGant = new Command(() =>
            {
                control.Content = new DiagramGant();
            }, () =>
            {
                return true;
            });
            //     edit
            EditWorkers = new Command(async () =>
            {
                var userUpdate = await UserClient.GetListUsersToUpdate();
                var rolesUpdate = await RoleClient.GetRolesList();
                control.Content = new EditWorkers(userUpdate, rolesUpdate);
            }, () =>
            {
                return true;
            });
            EditPosition = new Command(async () =>
            {
                var rolesList = await RoleClient.GetRolesList();
                
                control.Content = new EditDolzjnost(rolesList);
            }, () =>
            {
                return true;
            });
        }

    }
}
