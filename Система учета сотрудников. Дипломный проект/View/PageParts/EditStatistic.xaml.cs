using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Mapper;
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
                Statistics = AllStatistic.Where(s => s.IdUser == SelectedUser.Id );

                if (Statistics.LastOrDefault() == null)
                    Statistics = new List<UpdateStatisticDto>() { new UpdateStatisticDto() { IdUser = 0, HardSkils = 0, SoftSkils = 0, LevelResponibility = 0, QualityWork = 0 } };
               
                SelectedQuality = QualityWorkList.FirstOrDefault(s => s == Statistics.LastOrDefault().QualityWork);
                SelectedRespons = LevelResponibilityList.FirstOrDefault(s => s == Statistics.LastOrDefault().LevelResponibility);
                SelectedSoft = SoftSkilsList.FirstOrDefault(s => s == Statistics.LastOrDefault().SoftSkils);
                SelectedHard = HardSkilsList.FirstOrDefault(s => s == Statistics.LastOrDefault().HardSkils);


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

        public IEnumerable<int> QualityWorkList { get; set; } = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public IEnumerable<int> LevelResponibilityList { get; set; } = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public IEnumerable<int> SoftSkilsList { get; set; } = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        public IEnumerable<int> HardSkilsList { get; set; } = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


        public int SelectedQuality
        {
            get => selectedQuality;
            set
            {
                selectedQuality = value;
                if (SelectedStatistic != null)
                {
                    SelectedStatistic.QualityWork = value;
                    Signal(nameof(SelectedStatistic));
                }
                Signal();
            }
        }
        public int SelectedRespons
        {
            get => selectedRespons;
            set
            {
                selectedRespons = value;
                if (SelectedStatistic != null)
                {
                    SelectedStatistic.LevelResponibility = value;
                    Signal(nameof(SelectedStatistic));
                }
                Signal();
            }
        }
        public int SelectedSoft
        {
            get => selectedSoft;
            set
            {
                selectedSoft = value;
                if (SelectedStatistic != null)
                {
                    SelectedStatistic.SoftSkils = value;
                    Signal(nameof(SelectedStatistic));
                }
                Signal();
            }
        }
        public int SelectedHard
        {
            get => selectedHard;
            set
            {
                selectedHard = value;
                if (SelectedStatistic != null)
                {
                    SelectedStatistic.HardSkils = value;
                    Signal(nameof(SelectedStatistic));
                }
                Signal();
            }
        }


        public Command SaveCommand {  get; set; }
        public Command DeleteCommand {  get; set; }
        public Command AddCommand {  get; set; }


        IEnumerable<UpdateStatisticDto> AllStatistic;
        private int selectedQuality;
        private int selectedRespons;
        private int selectedSoft;
        private int selectedHard;

        public EditStatistic(IEnumerable<UserDTO> users, IEnumerable<UpdateStatisticDto> statistics)
        {
            //   Statistics = new List<UpdateStatisticDto>();
            // Statistics.Append(new UpdateStatisticDto { IdUser = 0, HardSkils = 0, SoftSkils =0, LevelResponibility = 0, QualityWork = 0});
            InitializeComponent();
            DataContext = this;
            Users = users;
            AllStatistic = statistics;
            SelectedUser = Users.First();
            SelectedStatistic = Statistics.LastOrDefault(s => s.IdUser == SelectedUser.Id);
            Statistics = AllStatistic.Where(s => s.IdUser == SelectedUser.Id);


            SaveCommand = new Command(async () =>
            {
                
                if (SelectedStatistic.Id == 0)
                {
                    SelectedStatistic.IdUser = SelectedUser.Id;
                    var asnw = await StatisticClient.Create(SelectedStatistic.ToDtoCreateFromUpdateDTO());
                    CheckResultAndGo(asnw, SystemMessages.SuccesSave);
                }
                else
                {
                    var answ = await StatisticClient.Update(SelectedStatistic);
                    CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
                }
               
               
            }, () =>
            {
                if (SelectedStatistic == null)
                {
                   // MessageBox.Show("Нажмите на кнопку добавить!");
                    return false;
                }
                if (SelectedUser.IdRole == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
            AddCommand = new Command(() =>
            {
                SelectedStatistic = new();
                SelectedStatistic.Id = 0;
                SelectedQuality = QualityWorkList.First();
                SelectedRespons = LevelResponibilityList.First();
                SelectedSoft = SoftSkilsList.First();
                SelectedHard = HardSkilsList.First();

            }, () =>
            {
                if (SelectedUser == null)
                {
                    return false;
                }
                else if (SelectedUser.IdRole == UserClient.ghostUser.IdRole)
                {
                    return false;
                }
                else
                    return true;
                
            });
            DeleteCommand = new Command(async () =>
            {
                var boxResult = MessageBox.Show($"Удалить статистику {SelectedUser.FIO} за {SelectedStatistic.DateCreate} число?", "Удаление статистики!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (boxResult == MessageBoxResult.Yes)
                {
                    var answ = await StatisticClient.Delete(SelectedStatistic.Id);
                    CheckResultAndGo(answ, SystemMessages.SuccessDelete);
                }
            }, () =>
            {
                if (SelectedStatistic == null)
                {
                    return false;
                }
                else  if (SelectedUser.IdRole == UserClient.ghostUser.IdRole)
                    return false;
                else
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
