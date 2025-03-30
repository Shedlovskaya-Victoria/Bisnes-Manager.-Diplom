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

namespace Система_учета_сотрудников._Дипломный_проект.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для EditStatistic.xaml
    /// </summary>
    public partial class EditStatistic : UserControl, INotifyPropertyChanged
    {
        private IEnumerable<UpdateStatisticDto> statistics;
        private UserDTO selectedUser;
        private IEnumerable<UserDTO> users;
        private UpdateStatisticDto selectedStatistic;


        public IEnumerable<int> QualityWorkList { get; set; } = new List<int>() { 1,2,3,4,5};
        public IEnumerable<int> LevelResponibilityList { get; set; } = new List<int>() { 1,2,3,4,5};
        public IEnumerable<int> SoftSkilsList { get; set; } = new List<int>() { 1,2,3,4,5};
        public IEnumerable<int> HardSkilsList { get; set; } = new List<int>() { 1,2,3,4,5};


        public int SelectedQuality {  get; set; }
        public int SelectedRespons {  get; set; }
        public int SelectedSoft {  get; set; }
        public int SelectedHard {  get; set; }


        public IEnumerable<UserDTO> Users 
        { 
            get => users;
            set
            {
                users = value;
                Signal();
            }
        }
        public UserDTO SelectedUser
        { 
            get => selectedUser;
            set
            {
                selectedUser = value;
                Signal();
            }
        }
        public IEnumerable<UpdateStatisticDto> Statistics 
        { 
            get => statistics;
            set
            {
                statistics = value;
                Signal();
            }
        }
        public UpdateStatisticDto SelectedStatistic 
        {
            get => selectedStatistic;
            set
            {
                selectedStatistic = value;
                Signal();
            }
        }
        public Command SaveCommand {  get; set; }
        public EditStatistic(IEnumerable<UserDTO> users, IEnumerable<UpdateStatisticDto> statistics)
        {
            InitializeComponent();
            DataContext = this;
            Users = users;
            Statistics = statistics;
            SelectedUser = Users.First();
            SelectedStatistic = Statistics.LastOrDefault(s => s.IdUser == SelectedUser.Id);


            SaveCommand = new Command(() =>
            {

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
