using BisnesManager.Client.Tools;
using BisnesManager.ETL.DTO;
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
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для EditDolzjnost.xaml
    /// </summary>
    public partial class EditDolzjnost : UserControl, INotifyPropertyChanged
    {
        private RoleDTO selectedRole;

        public RoleDTO SelectedRole { get => selectedRole;
            set
            {
                selectedRole = value;
                Signal();
            }
        }
        public IEnumerable<RoleDTO> RolesList { get; set; }
        public EditDolzjnost(IEnumerable<RoleDTO> rolesList)
        {

            RolesList = rolesList;
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
