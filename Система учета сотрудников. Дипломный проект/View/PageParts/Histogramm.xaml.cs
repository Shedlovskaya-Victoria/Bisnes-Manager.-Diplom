
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
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
using Color = ScottPlot.Color;


namespace BisnesManager.Client.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Histogramm.xaml
    /// </summary>
    public partial class Histogramm : UserControl
    {

         
        public IEnumerable<UserDTO> UsersList { get; set; }
        public IEnumerable<StatisticDTO> StatisticDTOs { get; set; }
        public Histogramm(IEnumerable<UserDTO> users, IEnumerable<StatisticDTO> statisticDTOs)
        {
            InitializeComponent();

            DataContext = this;

            //ГИСТОРАММА

            ScottPlot.Plot myPlot = WpfPlot1.Plot;
            foreach (UserDTO user in users)
            {
                var s = statisticDTOs.Where(s => s.UserId == user.Id).ToList();

                double[] heights = new double[s.Count()];
                for (int i = 0; i < s.Count(); i++) 
                {
                   // if(s[i].QualityWork!=null & s[i].SoftSkils!=null & s[i].HardSkils!=null & s[i].SoftSkils!=null)
                    heights[i] = (s[i].QualityWork + s[i].SoftSkils + s[i].HardSkils + s[i].SoftSkils);
                }
                var maxx = heights.Max();
                var hist = ScottPlot.Statistics.Histogram.WithFixedBinSize(0, 60, maxx);
                var barPlot = WpfPlot1.Plot.Add.Bars(hist.Bins, hist.GetProbability());
               
                
                foreach (var bar in barPlot.Bars)
                {
                    bar.Size = hist.BinSize;
                   // bar.LineWidth = 0;
                  //  bar.FillStyle.AntiAlias = false;
                    bar.FillColor = ScottPlot.Colors.Category20.ElementAtOrDefault(user.Id);
                }
                double[] xs = new double[heights.Length];

                for(int i = 1; i < heights.Count()+1; i++)
                {
                    xs[i-1] = (10*i)/2;
                }
               
                var curve = WpfPlot1.Plot.Add.ScatterLine(xs, heights);
                curve.LineWidth = 7; 
                curve.LineColor = ScottPlot.Colors.Category20.ElementAtOrDefault(user.Id);
                curve.LinePattern = LinePattern.DenselyDashed;
                curve.LegendText = user.FIO;
               

            }
            //// Create a histogram from a collection of values
            //double[][] heightsByGroup = { [ 6,3,2],[1,8,2] };
            //string[] groupNames = { "Male", "Female" };
            //Color[] groupColors = { ScottPlot.Colors.Blue, ScottPlot.Colors.Red };

            //for (int i = 0; i < 2; i++)
            //{
            //    double[] heights = heightsByGroup[i];
            //    var hist = ScottPlot.Statistics.Histogram.WithFixedBinSize(1, 10, heights[i]);

            //    // Display the histogram as a bar plot
            //    var barPlot = WpfPlot1.Plot.Add.Bars(hist.Bins, hist.GetProbability());

            //    // Customize the style of each bar
            //    foreach (var bar in barPlot.Bars)
            //    {
            //        bar.Size = hist.BinSize;
            //       // bar.LineWidth = 0;
            //        //bar.FillStyle.AntiAlias = false;
            //        bar.FillColor = groupColors[i].WithAlpha(.2);
            //    }

            //    //// Plot the probability curve on top the histogram
            //    // ScottPlot.Statistics.ProbabilityDensity pd = new(heights);
            //    double[] xs = { 1, 6, 7 };//Generate.Range(heights.Min(), heights.Max(), 1).ToArray();
            //    //double scale = 1.0 / hist.Bins.Sum();
            //    double[] ys = { 2,5,3}; //pd.GetYs(xs, scale);

            //    var curve = WpfPlot1.Plot.Add.ScatterLine(xs, ys);
            //    curve.LineWidth = 2;
            //    curve.LineColor = groupColors[i];
            //    curve.LinePattern = LinePattern.DenselyDashed;
            //    curve.LegendText = groupNames[i];
            //}
            ////2
            //for (int i = 0; i < 2; i++)
            //{
            //    double[] heights = heightsByGroup[i];
            //    var hist = ScottPlot.Statistics.Histogram.WithFixedBinSize(1, 10, heights[i]);

            //    // Display the histogram as a bar plot
            //    var barPlot = WpfPlot1.Plot.Add.Bars(hist.Bins, hist.GetProbability());

            //    // Customize the style of each bar
            //    foreach (var bar in barPlot.Bars)
            //    {
            //        bar.Size = hist.BinSize;
            //       // bar.LineWidth = 0;
            //        //bar.FillStyle.AntiAlias = false;
            //        bar.FillColor = groupColors[i].WithAlpha(.2);
            //    }

            //    //// Plot the probability curve on top the histogram
            //    // ScottPlot.Statistics.ProbabilityDensity pd = new(heights);
            //    double[] xs = { 1, 3, 7 };//Generate.Range(heights.Min(), heights.Max(), 1).ToArray();
            //    //double scale = 1.0 / hist.Bins.Sum();
            //    double[] ys = { 3,2,9}; //pd.GetYs(xs, scale);

            //    var curve = WpfPlot1.Plot.Add.ScatterLine(xs, ys);
            //    curve.LineWidth = 2;
            //    curve.LineColor = ScottPlot.Colors.Blue;
            //    curve.LinePattern = LinePattern.DenselyDashed;
            //    curve.LegendText = groupNames[i];
            //}

                // Customize plot style
                WpfPlot1.Plot.Legend.Alignment = Alignment.UpperRight;
                WpfPlot1.Plot.Axes.Margins(bottom: 0);
                WpfPlot1.Plot.YLabel("Probability (%)");
                WpfPlot1.Plot.XLabel("Height (cm)");
                WpfPlot1.Plot.HideGrid();

                WpfPlot1.Refresh();
        }

       
    }
}
