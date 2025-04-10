using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.Client.View.PageParts;
using BisnesManager.Client.View.Pages;
using BisnesManager.Client.View.ProgramUserControl;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;
using Система_учета_сотрудников._Дипломный_проект.View.PageParts;

namespace BisnesManager.Client.ViewModel
{
    public class HomeVM : Base
    {

        public CommandWithParametr<string> Find {  get; set; }

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

        

        public Visibility DiagramsStatisticVisibility {  get; set; } = Visibility.Collapsed;
        public Visibility EditMenuVisibility {  get; set; } = Visibility.Collapsed;
        public HomeVM() { }

        public HomeVM(ContentControl control, UserDTO user)
        {
            UserName = $"{user.Role}: {user.FIO}";

            if (user.IsEditWorkersRoles)
            {
                EditMenuVisibility = Visibility.Visible;
                Signal(nameof(EditMenuVisibility));
            }
            if (user.IsShowDiagramStatistic)
            {
                DiagramsStatisticVisibility = Visibility.Visible;
                Signal(nameof(DiagramsStatisticVisibility));
            }
            Find = new CommandWithParametr<string>((parametr) =>
            {
                control.Content = new TasksBoard(user.IdRole, user.Id, parametr);
            }, () =>
            {
                return true;
            });
            // go to
            GoToPersonalCabinet = new Command(async () =>
            {
                if (user.IdRole != UserClient.ghostUser.IdRole)
                {
                   var userUpdate = await UserClient.GetUserByIdToUpdate(UserClient.user.Id);
                   userUpdate.Password = "";

                    if(userUpdate==null)
                    {
                        MessageBox.Show(SystemMessages.UserIsNull);
                        return;
                    }
                   Navigation.Instance().CurrentPage = new PersonalCabinet(userUpdate);
                }
                else 
                    Navigation.Instance().CurrentPage = new PersonalCabinet(new ETL.update_DTO.UpdateUserDto() {Name = "Иван", Family="Иванович" });
            }, () =>
            {
                return true;
            });
            GoToHome = new Command(async () =>
            {
                
                control.Content = new TasksBoard(user.IdRole, user.Id, string.Empty);
               
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
                IEnumerable<UserDTO> listUsers;
                List<StatisticDTO> result = new List<StatisticDTO>();
                if (user.IdRole!=UserClient.ghostUser.IdRole)
                {
                    listUsers = await UserClient.GetAll();
                    var listStatistics = await StatisticClient.GetAllFilterDateAndPaginateQueryDto(100, 1, new DateTime(), new DateTime());
                    
                    foreach (UserDTO user in listUsers)
                    {
                        var s = listStatistics.Where(s => s.UserId == user.Id).ToList();

                        result.Add(s.FirstOrDefault(f => f.DateCreate == s.Max(s => s.DateCreate)));
                    }
                    if (result.Count == 0)
                    {
                        MessageBox.Show(SystemMessages.SatisticIsNull);
                        return;
                    }
                }
                else
                {
                    listUsers = new List<UserDTO>() { UserClient.ghostUser };
                    result.Add(new StatisticDTO { 
                        HardSkils = 5,
                        LevelResponibility = 6,
                        QualityWork = 7, 
                        SoftSkils = 8,
                        UserId =(int)UserClient.ghostUser.IdRole 
                    });
                }
               

                control.Content = new KPDWorkers(listUsers, result);
            }, () =>
            {
                return true;
            });
            ShowWorkersKPDGraphiks = new Command(async () =>
            {
                IEnumerable<UserDTO> listUsers;
                IEnumerable<StatisticDTO> listStatistics;
                if (user.IdRole != UserClient.ghostUser.IdRole)
                {
                    listUsers = await UserClient.GetAll();
                    listStatistics = await StatisticClient.GetAllFilterDateAndPaginateQueryDto(100, 1, new DateTime(), new DateTime());

                    if (listStatistics.Count() == 0)
                    {
                        MessageBox.Show(SystemMessages.SatisticIsNull);
                        return;
                    }
                }
                else
                {
                    listUsers = new List<UserDTO>() { UserClient.ghostUser };
                    listStatistics = new List<StatisticDTO>() { 
                        new StatisticDTO() { 
                            DateCreate = DateOnly.FromDateTime(DateTime.Now.Date), 
                            HardSkils = 6, 
                            QualityWork=3, 
                            SoftSkils=9, 
                            LevelResponibility=4 ,
                            UserId = UserClient.ghostUser.Id,
                        }
                    };
                }

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
                else if(user.IdRole == UserClient.ghostUser.IdRole)
                {
                    tasks = null;
                }
                else
                {
                    tasks = await TaskClient.GetUsersTasks(user.Id);
                }
                control.Content = new DiagramGant(tasks);
            }, () =>
            {
                return true;
            });
            //     edit
            EditWorkers = new Command(async () =>
            {
                List<UpdateUserDto> userUpdate;
                List<UpdateRoleDto> rolesUpdate;
                if (user.IdRole!=UserClient.ghostUser.IdRole)
                {
                    if (user.IdRole == 1)
                    {
                        userUpdate = await UserClient.GetListUsersToUpdate();
                        rolesUpdate = await RoleClient.GetAllFilterIsUse();
                    }
                    else
                    {
                        userUpdate = await UserClient.GetUsersFilterManagerToUpdate();
                        rolesUpdate = await RoleClient.GetRolesFilterManager();
                    }
                }
                else
                {
                    userUpdate = new() {
                        new UpdateUserDto { Id = UserClient.ghostUser.Id, Family = "Иванов", Name="Иван", IdRole = (short)UserClient.ghostUser.IdRole }
                    };
                    rolesUpdate = new()
                    {
                        new UpdateRoleDto{ 
                            Id = (short)UserClient.ghostUser.IdRole, 
                            Title = "гость", 
                            IsEditWorkersRoles = UserClient.ghostUser.IsEditWorkersRoles,
                            IsShowDiagramStatistic = UserClient.ghostUser.IsShowDiagramStatistic,
                            IsUse = true,
                            DateCreate = DateTime.Now,
                            },
                    } ;
                }
                control.Content = new EditWorkers(userUpdate, rolesUpdate);
            }, () =>
            {
                return true;
            });
            EditPosition = new Command(async () =>
            {
                List<UpdateRoleDto> rolesList;
                if (user.IdRole != UserClient.ghostUser.IdRole)
                {
                    if(user.IdRole == 1)
                    {
                        rolesList = await RoleClient.GetRolesList();
                    }
                    else
                    {
                        rolesList = await RoleClient.GetRolesFilterManager();
                    }
                }
                else
                {
                    rolesList = new() {  
                        new UpdateRoleDto{
                            Id = (short)UserClient.ghostUser.IdRole,
                            Title = "гость",
                            IsEditWorkersRoles = UserClient.ghostUser.IsEditWorkersRoles,
                            IsShowDiagramStatistic = UserClient.ghostUser.IsShowDiagramStatistic,
                            IsUse = true,
                            DateCreate = DateTime.Now,
                            },
                    };
                }

                control.Content = new EditDolzjnost(rolesList);
            }, () =>
            {
                return true;
            });
            EditStatistic = new Command(async () =>
            {
                IEnumerable<UserDTO> listUsers;
                IEnumerable<UpdateStatisticDto> listStatistic;
                if (user.IdRole != UserClient.ghostUser.IdRole)
                {
                     listUsers = await UserClient.GetAll();
                     listStatistic = await StatisticClient.GetAll();

                }
                else
                {
                    listUsers = new List<UserDTO>() { UserClient.ghostUser };
                    listStatistic = new List<UpdateStatisticDto>() {
                        new UpdateStatisticDto() {
                            DateCreate = DateTime.Now.Date,
                            HardSkils = 6,
                            QualityWork=3,
                            SoftSkils=9,
                            LevelResponibility=4 
                        }
                    };
                }

                control.Content = new EditStatistic(listUsers, listStatistic);
            }, () =>
            {
                return true;
            });
        }

    }
}
