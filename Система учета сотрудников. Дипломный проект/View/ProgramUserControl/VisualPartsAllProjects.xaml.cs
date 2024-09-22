using ScottPlot;
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
using Colors = ScottPlot.Colors;

namespace Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для VisualPartsAllProjects.xaml
    /// </summary>
    public partial class VisualPartsAllProjects : UserControl
    {
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public VisualPartsAllProjects()
        {
            InitializeComponent();

            DataContext = this;

            //Круговая диаграмма

            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            PieSlice slice1 = new() { Value = 5, FillColor = Colors.Red, Label = "Проект 1" };
            PieSlice slice2 = new() { Value = 2, FillColor = Colors.Orange, Label = "Задача beta" };
            PieSlice slice3 = new() { Value = 8, FillColor = Colors.Gold, Label = "Заказ gamma" };
            PieSlice slice4 = new() { Value = 4, FillColor = Colors.Green, Label = "Проект delta" };
            PieSlice slice5 = new() { Value = 8, FillColor = Colors.Blue, Label = "Диплом epsilon" };

            List<PieSlice> slices = new() { slice1, slice2, slice3, slice4, slice5 };

            // setup the pie to display slice labels
            var pie = myPlot.Add.Pie(slices);
            pie.ExplodeFraction = .1;
            pie.ShowSliceLabels = true;
            pie.SliceLabelDistance = 1.3;

            // color each label's text to match the slice
            slices.ForEach(x => x.LabelFontColor = x.FillColor);

            // styling can be customized for individual slices
            slice5.LabelStyle.FontSize = 22;
            slice5.LabelStyle.Bold = true;
            slice5.LabelStyle.Italic = true;

        }
    }
}
