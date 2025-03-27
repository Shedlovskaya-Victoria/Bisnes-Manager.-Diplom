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
using BisnesManager.ETL.update_DTO;
using Microsoft.AspNetCore.Rewrite;
using ScottPlot;
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
        private RoleDTO selectedRole;

        public string PageTitle { get; set; } = "Редактирование сотрудников";
        public List<UpdateUserDto> UsersList { 
            get => usersList;
            set
            {
                usersList = value;
                Signal();
            }
        }
        public List<RoleDTO> RolesList { get; set; }
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
        public RoleDTO SelectedRole
        { 
            get => selectedRole;
            set
            {
              
                selectedRole = value;
               
                Signal();
            }
        }
        public Command BackCommand {  get; set; }
        public EditWorkers(List<UpdateUserDto> userDTOs, List<RoleDTO> roles)
        {

            UsersList = userDTOs;
            RolesList = roles;
            SelectedUser = UsersList.First();
            SelectedRole = RolesList.First(s => s.Id == SelectedUser.IdRole);
            
            InitializeComponent();
            DataContext = this;
            BackCommand = new Command( () =>
            {
                Navigation.Instance().CurrentPage = new Home(UserClient.user);

            }, () =>
            {
                return true;
            });
        }
       
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
