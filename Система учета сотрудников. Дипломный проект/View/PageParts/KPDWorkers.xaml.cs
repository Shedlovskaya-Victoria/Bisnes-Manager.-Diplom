using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
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
using BisnesManager.Client.Tools;
using Colors = ScottPlot.Colors;
using BisnesManager.ETL.DTO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для KPDWorkers.xaml
    /// </summary>
    public partial class KPDWorkers : UserControl, INotifyPropertyChanged
    {
       
        ScottPlot.Plot newPLot = new();
        ScottPlot.WPF.WpfPlot wpfPLot = new();



        public IEnumerable<UserDTO> UsersList {  get; set; }
        public UserDTO SelectedUser { get => selectedUser;
            set
            {
                selectedUser = value;
                if (selectedUser != null)
                {
                    FindCards( StatisticDTOs.Where(S => S.UserId == value.Id).ToList(), ref newPLot, ref wpfPLot);
                }
                Signal();
            }
        }


        int StopCardAt = 0;
        private int finalCount;
        private int startCount = 1;
        private int secondCount;
        private int prevousFinalCount;
        private int selectedCountCards;
        private UserDTO selectedUser;

        public int StartCount { get => startCount;
            set
            {
                startCount = value;
                Signal();
            }
        }
        public int FinalCount { get => finalCount;
            set
            {
                finalCount = value;
                Signal();
            }
        }
        public int SecondCount { get => secondCount;
            set
            {
                secondCount = value;
                Signal();
            }
        }
        public int PrevousFinalCount { get => prevousFinalCount;
            set
            {
                prevousFinalCount = value;
                Signal();
            }
        }


        public Visibility VisibleSecondCount { get; set; } = Visibility.Hidden;
        public Visibility VisiblePrevousFinalCount { get; set; } = Visibility.Hidden;

        public int SelectedCountCards { get => selectedCountCards;
            set
            {
                selectedCountCards = value;
                FindCards(StatisticDTOs, ref newPLot, ref wpfPLot);
                Signal();
            }
        }
        public int[] ListCountCards { get; set; } = { 1, 3, 5, 10};


        public Command NextCardCommand { get; set; }
        public Command SetFirstCommand { get; set; }
        public Command SetSecondCountCommand { get; set; } 
        public Command SetPrevousFinalCountCommand { get; set; } 
        public Command SetLastCommand { get; set; } 


        public IEnumerable<StatisticDTO> StatisticDTOs { get; set; }
        public KPDWorkers(IEnumerable<UserDTO> users, IEnumerable<StatisticDTO> statisticDTOs)
        {
            StatisticDTOs = statisticDTOs;
            UsersList = users;
            SelectedUser = UsersList.First();
            SelectedCountCards = ListCountCards.First();
            FinalCount = statisticDTOs.Count();

            wpfPLot = new();
            newPLot = FillCard2(ref wpfPLot, statisticDTOs.First(S=>S.UserId==SelectedUser.Id));

            SetAdditionButttons(statisticDTOs);

            InitializeComponent();
            MainGrid.Children.Add(wpfPLot);

            //
            SetFirstCommand = new Command(() =>
            {
                StopCardAt = 1;
                FindCards(statisticDTOs, ref newPLot, ref wpfPLot);
            }, () =>
            {
                return true;
            });
            SetSecondCountCommand = new Command(() =>
            {
                StopCardAt = SecondCount;
                FindCards(statisticDTOs, ref newPLot, ref wpfPLot);
            }, () =>
            {
                return true;
            });
            SetPrevousFinalCountCommand = new Command(() =>
            {
                StopCardAt = PrevousFinalCount;
                FindCards(statisticDTOs, ref newPLot, ref wpfPLot);
            }, () =>
            {
                return true;
            });
            SetLastCommand = new Command(() =>
            {
                StopCardAt = statisticDTOs.Count() - SelectedCountCards;
                FindCards(statisticDTOs, ref newPLot, ref wpfPLot);
            }, () =>
            {
                return true;
            });
            //
            NextCardCommand = new Command(() =>
            {

                //WpfPlot1.Interaction.Disable();

                FindCards(statisticDTOs, ref newPLot, ref wpfPLot);


            }, () =>
            {
                return true;
            });

            DataContext = this;

            #region  диаграмма
            //  ScottPlot.Plot myPlot = WpfPlot1.Plot;
            //  myPlot.Axes.Title.Label.Text = $"Информационная карточка Пети за {1} число";

            //  var polarAxis = myPlot.Add.PolarAxis();
            //  polarAxis.RotationDegrees = -90;

            //  // add labeled spokes
            //  string[] labels = { "Качество работы", "Уровень ответвенности","Hard skill", "Soft skill" };
            //  polarAxis.SetSpokes(labels, length: 5.5);

            //  // add defined ticks
            //  double[] ticks = { 1, 2, 3, 4 };
            //  polarAxis.SetCircles(ticks);

            //  // convert radar values to coordinates
            //  double[] values1 = { 5, 4, 5, 2,};
            //  double[] values2 = { 2, 3, 2, 4,};
            //  Coordinates[] cs1 = polarAxis.GetCoordinates(values1);
            ////  Coordinates[] cs2 = polarAxis.GetCoordinates(values2);

            //  // add polygons for each dataset
            //  var poly1 = myPlot.Add.Polygon(cs1);
            //  poly1.FillColor = Colors.Green.WithAlpha(.5);
            //  poly1.LineColor = Colors.Black;

            // /*var poly2 = myPlot.Add.Polygon(cs2);
            //poly2.FillColor = Colors.Blue.WithAlpha(.5);
            //poly2.LineColor = Colors.Black;
            //*/
            #endregion


            if(statisticDTOs == null) 
            {
                ScottPlot.Plot newPLot2; //= new Plot();
                ScottPlot.WPF.WpfPlot wpfPLot2; //= new();
               // WpfPlots = new();
                /////////////////////////////////////////////////////////////////////////////////////////////////
                // WpfPlot1.Refresh();
                newPLot2 = new Plot();
                wpfPLot2 = new();
                newPLot2 = FillCard(ref wpfPLot2, 9);

                MainGrid.Children.Add(wpfPLot2);

             //   WpfPlot1.Refresh();
            }


         


           
        }
        private Plot FillCard2(ref WpfPlot wpfPlot, StatisticDTO stat)
        {
            Plot newPLot;
            wpfPLot.Name = $"карта{stat.UserId}";
            wpfPLot.MinHeight = 300;
            wpfPLot.Interaction.Disable();

            newPLot = wpfPLot.Plot;
            newPLot.Axes.Title.Label.Text = $"Карта: {UsersList.FirstOrDefault(s => s.Id == stat.UserId).FIO} за {stat.DateCreate} число";

            var polarAxisNew = newPLot.Add.PolarAxis();
            polarAxisNew.RotationDegrees = -90;
            string[] labelsNew = { "Качество", "Ответвенность", "Hard skils", "Soft skils" };
            double[] ticksNew = { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[] valuesNew = { stat.QualityWork, stat.LevelResponibility, stat.HardSkils, stat.SoftSkils, };

            polarAxisNew.SetSpokes(labelsNew, length: 5.5);
            polarAxisNew.SetCircles(ticksNew);
            Coordinates[] cs2New = polarAxisNew.GetCoordinates(valuesNew);

            var poly2New = newPLot.Add.Polygon(cs2New);
            poly2New.FillColor = Colors.Blue.WithAlpha(.5);
            poly2New.LineColor = Colors.Black;

            return newPLot;
        }
        private void FindCards(IEnumerable<StatisticDTO> statisticDTOs, ref Plot newPLot, ref WpfPlot wpfPLot)
        {
            if(MainGrid!=null)
                MainGrid.Children.Clear();
            if(MainGrid2!=null)
                MainGrid2.Children.Clear();
            if(MainGrid3!=null)
                MainGrid3.Children.Clear();
            if(MainGrid4!=null)
                MainGrid4.Children.Clear();
            if(MainGrid5!=null)
                MainGrid5.Children.Clear();
            if(MainGrid6!=null)
                MainGrid6.Children.Clear();
            if(MainGrid7!=null)
                MainGrid7.Children.Clear();
            if(MainGrid8!=null)
                MainGrid8.Children.Clear();
            if(MainGrid9!=null)
                MainGrid9.Children.Clear();
            if(MainGrid10!=null)
                MainGrid10.Children.Clear();

            //WpfPlot1.Interaction.Disable();
            if (SelectedCountCards == 1)
            {
                CheckRangeOut(statisticDTOs);


                if (MainGrid == null)
                    return;
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));
               
                MainGrid.Children.Add(wpfPLot);
                Signal(nameof(MainGrid));

            }
            else if (SelectedCountCards == 3)
            {

                //1
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid.Children.Add(wpfPLot);

                //2
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid2.Children.Add(wpfPLot);

                //3
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid3.Children.Add(wpfPLot);
            }
            else if (SelectedCountCards == 5)
            {
                //1
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid.Children.Add(wpfPLot);

                //2
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid2.Children.Add(wpfPLot);

                //3
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid3.Children.Add(wpfPLot);

                //4
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid4.Children.Add(wpfPLot);

                //5
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid5.Children.Add(wpfPLot);
            }
            else if (SelectedCountCards == 10)
            {
                //1
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid.Children.Add(wpfPLot);

                //2
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid2.Children.Add(wpfPLot);

                //3
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid3.Children.Add(wpfPLot);

                //4
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid4.Children.Add(wpfPLot);

                //5
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid5.Children.Add(wpfPLot);
                //6
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid6.Children.Add(wpfPLot);

                //7
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid7.Children.Add(wpfPLot);

                //8
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid8.Children.Add(wpfPLot);

                //9
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid9.Children.Add(wpfPLot);

                //10
                CheckRangeOut(statisticDTOs);
                wpfPLot = new();
                newPLot = FillCard2(ref wpfPLot, statisticDTOs.ElementAt(new Index(StopCardAt)));

                MainGrid10.Children.Add(wpfPLot);
            }
        }

        private void CheckRangeOut(IEnumerable<StatisticDTO> statisticDTOs)
        {
            if (StopCardAt >= statisticDTOs.Count() - 1)
            {
                StopCardAt = 0;
            }
            else
            {
                StopCardAt += 1;
            }
        }

        private void SetAdditionButttons(IEnumerable<StatisticDTO> statisticDTOs)
        {
            if (statisticDTOs.Count() > 10)
            {

                SecondCount = statisticDTOs.Count() / 4;
                PrevousFinalCount = statisticDTOs.Count() - SecondCount;

                VisibleSecondCount = Visibility.Visible;
                VisiblePrevousFinalCount = Visibility.Visible;
                Signal(nameof(VisibleSecondCount));
                Signal(nameof(VisiblePrevousFinalCount));
            }
        }

        private static Plot FillCard(ref WpfPlot wpfPLot, int i)
        {
            Plot newPLot;
            wpfPLot.Name = $"A{i}";
            wpfPLot.MinHeight = 300;
            wpfPLot.Interaction.Disable();

            newPLot = wpfPLot.Plot;
            newPLot.Axes.Title.Label.Text = $"Информационная карточка Лены{i} за {1} число";

            var polarAxisNew = newPLot.Add.PolarAxis();
            polarAxisNew.RotationDegrees = -90;

            // add labeled spokes
            string[] labelsNew = { "Качество работы", "Уровень ответвенности", "Рабочие навыки", "Комуникативные навыки" };
            polarAxisNew.SetSpokes(labelsNew, length: 5.5);

            // add defined ticks
            double[] ticksNew = { 1, 2, 3, 4 };
            polarAxisNew.SetCircles(ticksNew);

            // convert radar values to coordinates
           // double[] values1New = { 5, 4, 5, 2, };
            double[] values2New = { 2, 3, 2, 4, };
          //  Coordinates[] cs1New = polarAxisNew.GetCoordinates(values1New);
            Coordinates[] cs2New = polarAxisNew.GetCoordinates(values2New);

            // add polygons for each dataset
            // var poly1New = newPLot.Add.Polygon(cs1New);
          
            //if (!MainGrid.Children.Contains(wpfPLot))
          
            return newPLot;
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
