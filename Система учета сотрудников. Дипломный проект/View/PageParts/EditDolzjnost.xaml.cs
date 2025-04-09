using BisnesManager.Client.Tools;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
using System;
using System.Collections.Generic;
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
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для EditDolzjnost.xaml
    /// </summary>
    public partial class EditDolzjnost : UserControl, INotifyPropertyChanged
    {
        private UpdateRoleDto selectedRole;

        public UpdateRoleDto SelectedRole { get => selectedRole;
            set
            {
                selectedRole = value;
                Signal();
            }
        }
        public IEnumerable<UpdateRoleDto> RolesList { get; set; }
        public Command SaveCommand { get; set; }
        public Command BackCommand { get; set; }
        public EditDolzjnost(IEnumerable<UpdateRoleDto> rolesList)
        {

            RolesList = rolesList;
            SelectedRole = RolesList.First();
            InitializeComponent();
            DataContext = this;

           
           
            SaveCommand = new Command(async () =>
            {
               
                var answ = await RoleClient.UpdateRole(SelectedRole);
                CheckResultAndGo(answ, SystemMessages.SuccesSave);
                

            }, () =>
            {
                if (string.IsNullOrEmpty(SelectedRole.Title))
                    return false;
                else if (SelectedRole.Id == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
            BackCommand = new Command(() =>
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
    }
}
