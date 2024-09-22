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

namespace Система_учета_сотрудников._Дипломный_проект.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для WeekendsPlan.xaml
    /// </summary>
    public partial class WeekendsPlan : UserControl
    {
        public WeekendsPlan()
        {
            InitializeComponent();
            DataContext = this;

            //столчатая диаграмма с линией даты
 
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            myPlot.Axes.Title.Label.Text = "План отпусков";

            // plot sample DateTime data
            DateTime[] dates = Generate.ConsecutiveDays(100);
            double[] ys = Generate.RandomWalk(100);
            myPlot.Add.Scatter(dates, ys);
            myPlot.Axes.DateTimeTicksBottom();
        }
    }
}
