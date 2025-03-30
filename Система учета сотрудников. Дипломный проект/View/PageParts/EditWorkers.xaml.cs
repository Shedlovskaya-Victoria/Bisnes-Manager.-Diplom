using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisnesManager.Client.Model;
using BisnesManager.Client.Tools;
using BisnesManager.Client.View.ProgramUserControl;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Rewrite;
using ScottPlot;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для EditWorkers.xaml
    /// </summary>
    public partial class EditWorkers : UserControl, INotifyPropertyChanged
    {
        private UpdateUserDto selectedUser;
        private List<UpdateUserDto> usersList;
        private UpdateRoleDto selectedRole;
        private List<UpdateRoleDto> rolesList;

        public string PageTitle { get; set; } = "Редактирование сотрудников";
        public List<UpdateUserDto> UsersList { 
            get => usersList;
            set
            {
                usersList = value;
                Signal();
            }
        }
        public List<UpdateRoleDto> RolesList {
            get => rolesList; 
            set {
                rolesList = value;
                Signal();
            }
        }
        public UpdateUserDto SelectedUser
        { 
            get => selectedUser;
            set
            {
                SelectedRole = RolesList.FirstOrDefault(s => s.Id == value.IdRole);
                selectedUser = value;
                Signal();
            }
        }
        public UpdateRoleDto SelectedRole
        { 
            get => selectedRole;
            set
            {
                selectedRole = value;
                if (SelectedUser != null)
                {

                    SelectedUser.TitleRole = value.Title;
                    SelectedUser.IdRole = value.Id;
                    Signal(nameof(SelectedUser));
                }
                Signal();
            }
        }
        public Command BackCommand {  get; set; }
        public Command SaveCommand {  get; set; }
        public Command AddUserCommand {  get; set; }
        public Command DeleteCommand {  get; set; }
        public EditWorkers(List<UpdateUserDto> userDTOs, List<UpdateRoleDto> roles)
        {
            foreach(var user in userDTOs) 
            {
                user.Password = "";
            }

            UsersList = userDTOs;
            RolesList = roles;
            SelectedUser = UsersList.First();
            SelectedRole = RolesList.First(s => s.Id == SelectedUser.IdRole);
            
            InitializeComponent();

            DataContext = this;
            AddUserCommand = new Command( () =>
            {
                SelectedUser = new();
                SelectedUser.Id = 0;
               
            }, () =>
            {
                return true;
            });
            DeleteCommand = new Command( async () =>
            {
                var answ = MessageBox.Show($"Удалить {SelectedUser.Name} {SelectedUser.Family} {SelectedUser.Patronymic} ?","Удаление пользователя!",MessageBoxButton.YesNo,MessageBoxImage.Question);

                if(answ == MessageBoxResult.Yes)
                {
                    var requestAnsw = await UserClient.DeleteUser(SelectedUser.Id);
                    CheckResultAndGo(requestAnsw, SystemMessages.SuccessDelete);

                }

            }, () =>
            {
                if (SelectedUser.Id == 0)
                    return false;
                else
                    return true;
            });
            SaveCommand = new Command( async () =>
            {
                if (SelectedUser.Id == 0)
                {


                    if (string.IsNullOrEmpty(SelectedUser.Password))
                        return;

                    var answ = await UserClient.CreateUser(SelectedUser.ToUserCreateFromUpdateDTO());

                    CheckResultAndGo(answ, SystemMessages.SuccesSave);
                }
                else
                {
                    var answ = await UserClient.UpdateUser(SelectedUser);
                    CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
                }
            }, () =>
            {
                if (string.IsNullOrEmpty(SelectedUser.CheckPhrase))
                    return false;
                else if (string.IsNullOrEmpty(SelectedUser.Name))
                    return false;
                else if(string.IsNullOrEmpty(SelectedUser.Family))
                    return false;
                else if(string.IsNullOrEmpty(SelectedUser.Email))
                    return false;
                else if(!SelectedUser.Email.Contains("@"))
                    return false;
                else if(!SelectedUser.Email.Contains("."))
                    return false;
                else if (string.IsNullOrEmpty(SelectedUser.Login))
                    return false;
                else if (string.IsNullOrEmpty(SelectedUser.TitleRole))
                    return false;
                else
                    return true;
            });
            BackCommand = new Command( () =>
            {
                Navigation.Instance().CurrentPage = new Home(UserClient.user);

            }, () =>
            {
                return true;
            });
        }

        private static void CheckResultAndGo(string requestAnsw, string systemMessage)
        {
            if (requestAnsw == systemMessage)
            {
                MessageBox.Show(requestAnsw);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
            }
            else
            {
                MessageBox.Show(requestAnsw);
                return;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
