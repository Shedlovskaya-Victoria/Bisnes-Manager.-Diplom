using BisnesManager.Client.Tools;
using BisnesManager.Client.View.PageParts;
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WPF;
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
using Colors = ScottPlot.Colors;

namespace BisnesManager.Client.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для VisualPartsAllProjects.xaml
    /// </summary>
    public partial class VisualPartsAllProjects : UserControl, INotifyPropertyChanged
    {
        static short? IdRole;
        static int IdUser;

        private static DateTime startDate = new();
        private static DateTime finalDate = DateTime.Parse($"01.12.{DateTime.Now.Year}");

        static List<PieSlice> slices = new();



        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
            }
        }
        public DateTime FinalDate
        {
            get => finalDate;
            set
            {
                finalDate = value;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public Command SearchCommand { get; set; }
        public VisualPartsAllProjects(int idUser, short? idRole)
        {
            InitializeComponent();

            DataContext = this;
            IdRole = idRole;
            IdUser = idUser;
            SearchCommand = new Command(async () =>
            {
                WpfPlot1.Plot.Clear();
                if (IdRole == 1)
                {
                    IEnumerable<BisnesTaskDTO> list = await GetAll();
                    FillPieSlices(list);
                }
                else if (IdRole == UserClient.ghostUser.IdRole)
                {
                    PieSlice slice1 = new() { Value = 5, FillColor = Colors.Red, Label = "Проект 1" };
                    PieSlice slice2 = new() { Value = 2, FillColor = Colors.Orange, Label = "Задача beta" };
                    PieSlice slice3 = new() { Value = 8, FillColor = Colors.Gold, Label = "Заказ gamma" };
                    PieSlice slice4 = new() { Value = 4, FillColor = Colors.Green, Label = "Проект delta" };
                    PieSlice slice5 = new()
                    {
                        Value = 8,
                        FillColor = Colors.Blue,
                        Label = "Диплом epsilon",
                        LabelFontSize = 22,
                        LabelBold = true,
                        LabelItalic = true,
                    };

                    slices.AddRange([slice1, slice2, slice3, slice4, slice5]);
                }
                else 
                {
                    IEnumerable<BisnesTaskDTO> list = await GetUsersTasks(IdUser);
                    FillPieSlices(list);
                }
                var pie2 = WpfPlot1.Plot.Add.Pie(slices);
                pie2.ExplodeFraction = .1;
                pie2.ShowSliceLabels = true;
                pie2.SliceLabelDistance = 1.3;
                slices.ForEach(x => x.LabelFontColor = x.FillColor);
                WpfPlot1.Refresh();
            }, () =>
            {
                return true;
            });
            //Круговая диаграмма

            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            myPlot.Axes.Title.Label.Text = "Доли всех проектов в компании за время";


            // setup the pie to display slice labels
            var pie = myPlot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 10;

            // color each label's text to match the slice
            slices.ForEach(x => x.LabelFontColor = x.FillColor);

            // styling can be customized for individual slices
        }
        private static async void FillPieSlices(IEnumerable<BisnesTaskDTO> list)
        {
            slices = new();
            foreach (var b in list)
            {
                slices.Add(new PieSlice()
                {
                    Value = b.EndDate.Date.ToOADate() - b.StartDate.Date.ToOADate(),
                    Label = b.Content,
                    FillColor = Colors.Category20.ElementAtOrDefault(b.Id),
                    LabelFontSize = 22,
                    LabelBold = true,
                    LabelItalic = true,
                });
            }

        }

        private static async Task<IEnumerable<BisnesTaskDTO>> GetUsersTasks(int IdUser)
        {
            return await TaskClient.GetUsersTasks(IdUser);

        }
        private async Task<IEnumerable<BisnesTaskDTO>> GetAll()
        {
          
            return await TaskClient.GetAllTasks(StartDate, FinalDate);

        }
    }

      
    
}
