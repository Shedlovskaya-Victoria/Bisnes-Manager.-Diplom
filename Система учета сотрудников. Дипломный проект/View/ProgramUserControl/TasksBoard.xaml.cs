
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
using Система_учета_сотрудников._Дипломный_проект.Tools;

namespace Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public partial class TasksBoard : UserControl
    {
     public List<SampleToDelete> PlaneList { get; set; }
     public List<SampleToDelete> WorkList { get; set; }
     public List<SampleToDelete> EndList { get; set; }
        public TasksBoard()
        {

            InitializeComponent();

            PlaneList = new List<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = " aaa1"},
                new SampleToDelete(){ TextList = " aaa2"},
                new SampleToDelete(){ TextList = " aaa3"},
                new SampleToDelete(){ TextList = " aaa4"},
                new SampleToDelete(){ TextList = " aaa5"},
            };
            WorkList = new List<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = " bbbb1"},
                new SampleToDelete(){ TextList = " bbbb2"},
                new SampleToDelete(){ TextList = " bbbb3"},
             //   new SampleToDelete(){ TextList = " bbbb4"},
             //   new SampleToDelete(){ TextList = " bbbb5"},
             //   new SampleToDelete(){ TextList = " bbbb6"},
            };
            EndList = new List<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = "в1"},
                new SampleToDelete(){ TextList = "в2"},
                new SampleToDelete(){ TextList = "в3"},
                new SampleToDelete(){ TextList = "в4"},
            //    new SampleToDelete(){ TextList = "в5"},
            //    new SampleToDelete(){ TextList = "в6"},
             //   new SampleToDelete(){ TextList = "в7"},
            };


            DataContext = this;
        }
    }
}
