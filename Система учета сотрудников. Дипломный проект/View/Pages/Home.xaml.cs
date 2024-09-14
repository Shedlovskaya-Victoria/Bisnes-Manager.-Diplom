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
using Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl;
using Система_учета_сотрудников._Дипломный_проект.ViewModel;

namespace Система_учета_сотрудников._Дипломный_проект.View
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            contentControl = new Tasks();
            InitializeComponent();
            DataContext = new HomeVM(contentControl);
        }
    }
}
