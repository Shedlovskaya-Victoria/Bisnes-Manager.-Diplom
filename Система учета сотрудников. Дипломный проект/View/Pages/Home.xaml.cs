using System;
using System.Collections.Generic;
using System.Linq;
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
using BisnesManager.Client.View.ProgramUserControl;
using BisnesManager.Client.ViewModel;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home(UserDTO userDTO)
        {
            InitializeComponent();
            contentControl.Content = new TasksBoard(userDTO.IdRole, userDTO.Id);
            DataContext = new HomeVM(contentControl, userDTO);
        }
    }
}
