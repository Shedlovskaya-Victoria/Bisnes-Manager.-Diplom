
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
using BisnesManager.Client.Model;
using BisnesManager.Client.Tools;
using BisnesManager.ETL.DTO;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.DragDrop;

namespace BisnesManager.Client.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public delegate void Deleg();
    public partial class TasksBoard : UserControl
    {
        public ObservableCollection<BisnesTaskDTO> PlaneList { get; set; }
        public ObservableCollection<BisnesTaskDTO> WorkList { get; set; }
        public ObservableCollection<BisnesTaskDTO> EndList { get; set; }
        public ObservableCollection<BisnesTaskDTO> ArchiveList { get; set; }

        public TasksBoard(int UserId, short? IdRole, bool IsUsePlaneStatus, bool IsUseWorkStatus, bool IsUseEndStatus, bool IsUseArchiveStatus)
        {
            PlaneList = new();
            WorkList = new();
            EndList = new();
            ArchiveList = new();

            InitializeComponent();

            if(IdRole == 6)
            {
                SetDefoultTasks();
            }
            if(IdRole == 1)
            {
                SetAllTasks(IsUsePlaneStatus, IsUseWorkStatus, IsUseEndStatus, IsUseArchiveStatus);
            }
            if(IdRole == 4)
            {
                SetUserTasks(UserId, IsUsePlaneStatus, IsUseWorkStatus, IsUseEndStatus, IsUseArchiveStatus);
            }

            DataContext = this;
        
        }

        private async void SetUserTasks(int userId, bool IsUsePlaneStatus, bool IsUseWorkStatus, bool IsUseEndStatus, bool IsUseArchiveStatus)
        {
            var allList = await TaskClient.GetUsersTasks(userId);

            if (allList == null)
                return;

            foreach (var task in allList)
            {
                CheckPlaneStatus(task, IsUsePlaneStatus);
                CheckWorkStatus(task, IsUseWorkStatus);
                CheckEndStatus(task, IsUseEndStatus);
                CheckArchiveStatus(task, IsUseArchiveStatus);
            }
        }

        private async void SetAllTasks(bool IsUsePlaneStatus, bool IsUseWorkStatus, bool IsUseEndStatus, bool IsUseArchiveStatus)
        {
           var allList =  await TaskClient.GetAllTasks();

            foreach (var task in allList)
            {
                CheckPlaneStatus(task, IsUsePlaneStatus);
                CheckWorkStatus(task, IsUseWorkStatus);
                CheckEndStatus(task, IsUseEndStatus);
                CheckArchiveStatus(task, IsUseArchiveStatus);
            }
        }

        private void CheckArchiveStatus(BisnesTaskDTO task, bool IsUseArchiveStatus)
        {
            if(IsUseArchiveStatus)
            {
                if (task.IdStatus == 7)
                    ArchiveList.Add(task);
            }
        }

        private void CheckEndStatus(BisnesTaskDTO task, bool IsUseEndStatus)
        {
            if (IsUseEndStatus)
            {
                if (task.IdStatus == 6)
                    EndList.Add(task);
            }
        }

        private void CheckWorkStatus(BisnesTaskDTO task, bool IsUseWorkStatus)
        {
            if (IsUseWorkStatus)
            {
                if (task.IdStatus == 5)
                    WorkList.Add(task);
            }
        }

        private void CheckPlaneStatus(BisnesTaskDTO task, bool IsUsePlaneStatus)
        {
            if (IsUsePlaneStatus)
            {
                if (task.IdStatus == 1)
                    PlaneList.Add(task);
            }
        }

        private void SetDefoultTasks()
        {
            var startDate =DateTime.Now.Date;
           var endDate = DateTime.Now.AddDays(2).Date;
            PlaneList = new ObservableCollection<BisnesTaskDTO>()
            {
                new BisnesTaskDTO(){Author="test", Content = " aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa1", AssignmentsContent ="aaa1", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Саша", Content = " aaa2", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Нолик", Content = " aaa3", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Франц Кафка", Content = " aaa4", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Ацуши", Content = " aaa5", StartDate = startDate, EndDate = endDate },
            };
            WorkList = new ObservableCollection<BisnesTaskDTO>()
            {
                new BisnesTaskDTO(){Author = "Петя",  Content = " bbbbbbbbbbbbaaaaabbbbbbbbbb1", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Игрек", Content = " bbbbbbb2", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Асагири", Content = " bbbbbbb3", StartDate = startDate, EndDate = endDate },
            };
            EndList = new ObservableCollection<BisnesTaskDTO>()
            {
                new BisnesTaskDTO(){Author="Ваня", Content = "иииииииииииииииaaaaaaaaaaиииииииив1", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="абвгде", Content = "в2", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Икс", Content = "в3", StartDate = startDate, EndDate = endDate },
                new BisnesTaskDTO(){Author="Равно", Content = "в4", StartDate = startDate, EndDate = endDate },
            };
        }

        private void MouseDROPMethod(object sender, DragEventArgs e)
        {

        }

        private void MouseUPMethod(object sender, MouseEventArgs e)
        {
            var data = sender.GetType();
            if (data == typeof(BisnesTaskDTO)) MessageBox.Show("a");
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                //     DataObject data = new(typeof(SampleToDelete), image1.Source);
                DragDrop.DoDragDrop(this, data, DragDropEffects.Move);
            }
        }
    }
}
