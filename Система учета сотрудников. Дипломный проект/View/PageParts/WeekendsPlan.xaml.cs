using DlhSoft.Windows.Controls;
using DlhSoft.Windows.Data;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Система_учета_сотрудников._Дипломный_проект.Model;
using Colors = ScottPlot.Colors;

namespace Система_учета_сотрудников._Дипломный_проект.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для WeekendsPlan.xaml
    /// </summary>
    public partial class WeekendsPlan : UserControl
    {
        public ObservableCollection<SampleToDelete> List { get; set; }
        public WeekendsPlan()
        {
            InitializeComponent();
            DataContext = this;
            List = new ObservableCollection<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = " gbbbb1"},
                new SampleToDelete(){ TextList = " gbbbb2"},
                new SampleToDelete(){ TextList = " gbbbb3"},
                new SampleToDelete(){ TextList = " gbbbb4"},
                new SampleToDelete(){ TextList = " gbbbb5"},
                new SampleToDelete(){ TextList = " gbbbb6"},
            };
        }
    }
}
