
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

            ScottPlot.Plot myPlot = new();

            // visible items have public properties that can be customized
            myPlot.Axes.Bottom.Label.Text = "Horizontal Axis";
            myPlot.Axes.Left.Label.Text = "Vertical Axis";
            myPlot.Axes.Title.Label.Text = "";

            ScottPlot.Bar[] bars =
            {
    new() { Position = 1, Value =  5,  Label = "Качество работы" },
    new() { Position = 2, Value = 7, Error = 2, },
    new() { Position = 3, Value = 6, Error = 1, },
    new() { Position = 4, Value = 8, Error = 2, },
};

            var barPlot = myPlot.Add.Bars(bars);
            barPlot.Horizontal = true;

            myPlot.Axes.Margins(left: 0);

            WpfPlot1.Plot.Title("Plot Title");
           // WpfPlot1.Plot.Add.(myPlot.Axes.Left);
            WpfPlot1.Plot.Axes.AddLeftAxis(myPlot.Axes.Left);
            WpfPlot1.Plot.Axes.AddBottomAxis(myPlot.Axes.Bottom);

          //  myPlot.SavePng("demo.png", 400, 300);
            WpfPlot1.Refresh();
        }

       
    }
}
