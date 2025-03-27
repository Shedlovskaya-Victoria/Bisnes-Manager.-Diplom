using BisnesManager.Client.ViewModel;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.update_DTO;
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

namespace BisnesManager.Client.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalCabinet.xaml
    /// </summary>
    public partial class PersonalCabinet : Page
    {
        public PersonalCabinet(UpdateUserDto updateUserDto)
        {
            InitializeComponent();
            DataContext = new PersonalCabinetVM(updateUserDto);
        }
    }
}
