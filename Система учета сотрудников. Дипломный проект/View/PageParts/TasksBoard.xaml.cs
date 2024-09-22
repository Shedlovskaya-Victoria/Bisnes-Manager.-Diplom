
//using GongSolutions.Wpf.DragDrop;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.DragDrop;

namespace Система_учета_сотрудников._Дипломный_проект.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public delegate void Deleg();
    public partial class TasksBoard : UserControl
    {
        public ObservableCollection<SampleToDelete> PlaneList { get; set; }
        public ObservableCollection<SampleToDelete> WorkList { get; set; }
        public ObservableCollection<SampleToDelete> EndList { get; set; }

        public TasksBoard()
        {

            InitializeComponent();

            PlaneList = new ObservableCollection<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = " aaa1"},
                new SampleToDelete(){ TextList = " aaa2"},
                new SampleToDelete(){ TextList = " aaa3"},
                new SampleToDelete(){ TextList = " aaa4"},
                new SampleToDelete(){ TextList = " aaa5"},
            };
            WorkList = new ObservableCollection<SampleToDelete>()
            {
                new SampleToDelete(){ TextList = " bbbb1"},
                new SampleToDelete(){ TextList = " bbbb2"},
                new SampleToDelete(){ TextList = " bbbb3"},
             //   new SampleToDelete(){ TextList = " bbbb4"},
             //   new SampleToDelete(){ TextList = " bbbb5"},
             //   new SampleToDelete(){ TextList = " bbbb6"},
            };
            EndList = new ObservableCollection<SampleToDelete>()
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

        
       
        private void MouseDROPMethod(object sender, DragEventArgs e)
        {

        }

        private void MouseUPMethod(object sender, MouseEventArgs e)
        {
            var data = sender.GetType();
            if (data == typeof(SampleToDelete)) MessageBox.Show("a");
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //     DataObject data = new(typeof(SampleToDelete), image1.Source);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }
    }
}
