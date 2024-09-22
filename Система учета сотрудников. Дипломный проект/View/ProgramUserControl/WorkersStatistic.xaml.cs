
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


namespace Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Workers.xaml
    /// </summary>
    public partial class Workers : UserControl
    {
        public Workers()
        {
            InitializeComponent();

            DataContext = this;

            //КОЛОНКИ

            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            // visible items have public properties that can be customized
            myPlot.Axes.Bottom.Label.Text = "Уровень";
            myPlot.Axes.Left.Label.Text = "Сотрудники";
            myPlot.Axes.Title.Label.Text = "График достижений";

            //don't work
            myPlot.Axes.Bottom.Label.Padding = 13;
            myPlot.Axes.Left.Label.Padding = 13;
            myPlot.Axes.Title.Label.Padding = 13;

            //size text/ don't know work or not
            myPlot.Axes.Bottom.Label.FontSize = 17;
            myPlot.Axes.Left.Label.FontSize = 17;
            myPlot.Axes.Title.Label.FontSize = 18;

            //колонки сами
            ScottPlot.Bar[] bars =
            {
                new() { Position = 1, Value =  5, Error = 1, FillColor = ScottPlot.Colors.Yellow },
                new() { Position = 2, Value = 7, Error = 2, FillColor = ScottPlot.Colors.LightCoral},
                new() { Position = 3, Value = 6, Error = 1, FillColor = ScottPlot.Colors.AliceBlue},
                new() { Position = 4, Value = 8, Error = 2, FillColor = ScottPlot.Colors.AntiqueWhite},
            };
            //обозначения колонок
            Tick[] ticks =
            {
                new(1, "Вася"),
                new(2, "Петя"),
                new(3, "Лера"),
                new(4, "Илья"),
            };

            //регистрируемся
            myPlot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);
            myPlot.Axes.Left.TickLabelStyle.FontSize = 18;
            myPlot.Axes.Bottom.MajorTickStyle.Length = 0;
            myPlot.ShowLegend();

            var barPlot = myPlot.Add.Bars(bars);
            barPlot.Horizontal = true;

            myPlot.Axes.Margins(left: 0);
            WpfPlot1.Plot.Add.Bars(bars);
            WpfPlot1.Refresh();
        }

       
    }
}
