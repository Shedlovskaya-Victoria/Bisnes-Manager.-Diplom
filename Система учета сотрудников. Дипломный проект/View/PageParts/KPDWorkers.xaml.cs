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
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Colors = ScottPlot.Colors;

namespace Система_учета_сотрудников._Дипломный_проект.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для KPDWorkers.xaml
    /// </summary>
    public partial class KPDWorkers : UserControl
    {
        // public ListView<Plot> ListDiagrams { get; set; }

        public uint MinCountCards { get; set; }
        public uint[] CountToViewCards { get; set; } = { 1, 3, 5, 10};
        public Command NextCard { get; set; } 

        public KPDWorkers()
        {
            InitializeComponent();


            NextCard = new Command(() =>
            {
            }, () =>
            {
                return true;
            });

            DataContext = this;

            //Круговая диаграмма

            WpfPlot1.Interaction.Disable();
            ScottPlot.Plot myPlot = WpfPlot1.Plot;

            myPlot.Axes.Title.Label.Text = "Информационные карточка Пети";


            var polarAxis = myPlot.Add.PolarAxis();
            polarAxis.RotationDegrees = -90;

            // add labeled spokes
            string[] labels = { "Качество работы", "Уровень ответвенности", "Эффективность коммуникации", 
                "Рабочие навыки", "Комуникативные навыки" };
            polarAxis.SetSpokes(labels, length: 5.5);

            // add defined ticks
            double[] ticks = { 1, 2, 3, 4, 5 };
            polarAxis.SetCircles(ticks);

            // convert radar values to coordinates
            double[] values1 = { 5, 4, 5, 2, 3 };
            double[] values2 = { 2, 3, 2, 4, 2 };
            Coordinates[] cs1 = polarAxis.GetCoordinates(values1);
            Coordinates[] cs2 = polarAxis.GetCoordinates(values2);

            // add polygons for each dataset
            var poly1 = myPlot.Add.Polygon(cs1);
            poly1.FillColor = Colors.Green.WithAlpha(.5);
            poly1.LineColor = Colors.Black;


            /*var poly2 = myPlot.Add.Polygon(cs2);
            poly2.FillColor = Colors.Blue.WithAlpha(.5);
            poly2.LineColor = Colors.Black;
            */


            /////////////////////////////////////////////////////////////////////////////////////////////////
            for (int i = 1; i <= 10; i++)
            {
                ScottPlot.Plot newPLot = new Plot();


                ScottPlot.WPF.WpfPlot a = new();
                a.Name = $"A{i}";
                a.MinHeight = 300;
                a.Interaction.Disable();

                newPLot = a.Plot;

                newPLot.Axes.Title.Label.Text = $"Информационные карточка Лены{i}";


                var polarAxisNew = newPLot.Add.PolarAxis();
                polarAxisNew.RotationDegrees = -90;

                // add labeled spokes
                string[] labelsNew = { "Качество работы", "Уровень ответвенности", "Эффективность коммуникации",
                "Рабочие навыки", "Комуникативные навыки" };
                polarAxisNew.SetSpokes(labelsNew, length: 5.5);

                // add defined ticks
                double[] ticksNew = { 1, 2, 3, 4, 5 };
                polarAxisNew.SetCircles(ticksNew);

                // convert radar values to coordinates
                double[] values1New = { 5, 4, 5, 2, 3 };
                double[] values2New = { 2, 3, 2, 4, 2 };
                Coordinates[] cs1New = polarAxisNew.GetCoordinates(values1New);
                Coordinates[] cs2New = polarAxisNew.GetCoordinates(values2New);

                // add polygons for each dataset
                var poly2New = newPLot.Add.Polygon(cs2New);
                poly2New.FillColor = Colors.Blue.WithAlpha(.5);
                poly2New.LineColor = Colors.Black;

                if (!MainGrid.Children.Contains(a))
                    MainGrid.Children.Add(a);

                newPLot = new Plot();
                 a = new();
                WpfPlot1.Refresh();
            }
           
        }
    }
}
