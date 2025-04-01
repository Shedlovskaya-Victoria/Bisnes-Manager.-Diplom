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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;
using Система_учета_сотрудников._Дипломный_проект.View.PageParts;

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
        public Command EditStatistic {  get; set; }


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
            ShowKPDWorkers = new Command(async () =>
            {
                var listUsers = await UserClient.GetAll();
                var listStatistics = await StatisticClient.GetAllFilterDateAndPaginateQueryDto(100, 1,new DateTime(), new DateTime());
                control.Content = new KPDWorkers(listUsers, listStatistics);
            }, () =>
            {
                return true;
            });
            ShowWorkersKPDGraphiks = new Command(async () =>
            {
                var listUsers = await UserClient.GetAll();
                var listStatistics =  await StatisticClient.GetAllFilterDateAndPaginateQueryDto(100, 1, new DateTime(), new DateTime()) ;
                control.Content = new Histogramm(listUsers, listStatistics);
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
            ShowDiagramGant = new Command(async () =>
            {
                IEnumerable<BisnesTaskDTO> tasks;
                if(user.IdRole == 1)
                {
                    tasks = await TaskClient.GetAllTasks(new DateTime(), new DateTime());
                }
                else if(user.IdRole == 4)
                {
                    tasks = await TaskClient.GetUsersTasks(user.Id);
                }
                else
                {
                    tasks = null;
                }
                control.Content = new DiagramGant(tasks);
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
            EditStatistic = new Command(async () =>
            {

                var listUsers = await UserClient.GetAll();
                var listStatistic = await StatisticClient.GetAll();
                control.Content = new EditStatistic(listUsers, listStatistic);
            }, () =>
            {
                return true;
            });
        }

    }
}
