
//using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Mapper;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;
using Система_учета_сотрудников._Дипломный_проект.View.Windows;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.DragDrop;

namespace BisnesManager.Client.View.ProgramUserControl
{
    /// <summary>
    /// Логика взаимодействия для Tasks.xaml
    /// </summary>
    public delegate void Deleg();
    public partial class TasksBoard : UserControl, INotifyPropertyChanged
    {
        private BisnesTaskDTO selectedTask;

        public ObservableCollection<BisnesTaskDTO> PlaneList { get; set; }
        public ObservableCollection<BisnesTaskDTO> WorkList { get; set; }
        public ObservableCollection<BisnesTaskDTO> EndList { get; set; }
        public ObservableCollection<BisnesTaskDTO> ArchiveList { get; set; }

        public BisnesTaskDTO SelectedTask { get => selectedTask;
            set
            {
                selectedTask = value;
                Signal();
            }
        }
        public Visibility LastTasksVisible { get; set; } = Visibility.Visible;
        public Visibility ArchiveTaskVisible { get; set; } = Visibility.Collapsed;

        public Command ShowArchiveCommand { get; set; }
        public Command ShowLastTasksCommand { get; set; }
        public Command AddTaskCommand {  get; set; }
        public CommandWithParametr<BisnesTaskDTO> EditTaskCommand { get; set; }
        public CommandWithParametr<BisnesTaskDTO> DeleteTaskCommand { get; set; }
        public Command SaveCommand {  get; set; }
        public CommandWithParametr<BisnesTaskDTO> AddToArchiveCommand {  get; set; }
        public CommandWithParametr<BisnesTaskDTO> ChangeArchStatusCommand {  get; set; }

        public TasksBoard(short? RoleId, short UserId, string searchTextBox)
        {
            PlaneList = new();
            WorkList = new();
            EndList = new();
            ArchiveList = new();

            InitializeComponent();

            DataContext = this;

            
            if (RoleId == UserClient.ghostUser.IdRole)
            {
                SetDefoultTasks();
            }
            else if (RoleId == 1)
            {
                SetAdminTasks(searchTextBox);
            }
            else 
            {
                SetUserTask(UserId, searchTextBox);
            }

            DataContext = this;

            ShowArchiveCommand = new Command(() =>
            {
                PlaneList = new();
                WorkList = new();
                EndList = new();
                ArchiveList = new();

                LastTasksVisible = Visibility.Collapsed;
                ArchiveTaskVisible = Visibility.Visible;
                Signal(nameof(LastTasksVisible));
                Signal(nameof(ArchiveTaskVisible));

                if (RoleId == 1)
                {
                    SetArchAdminTasks();
                }
                else if (RoleId == UserClient.ghostUser.IdRole)
                {
                    SetDefoultTasks();
                }
                else 
                {
                    SetArchUserTask(UserId);
                }

                Signal(nameof(PlaneList));
                Signal(nameof(WorkList));
                Signal(nameof(EndList));
                Signal(nameof(ArchiveList));

            }, () =>
            {
                return true;
            });

            ShowLastTasksCommand = new Command(() =>
            {  
                PlaneList = new();
                WorkList = new();
                EndList = new();
                ArchiveList = new();

                ArchiveTaskVisible = Visibility.Collapsed;
                LastTasksVisible = Visibility.Visible;
                Signal(nameof(LastTasksVisible));
                Signal(nameof(ArchiveTaskVisible));

                if (RoleId == UserClient.ghostUser.IdRole)
                {
                    SetDefoultTasks();
                }
                else if (RoleId == 1)
                {
                    SetAdminTasks(searchTextBox);
                }
                else 
                {
                    SetUserTask(UserId, searchTextBox);
                }

                Signal(nameof(PlaneList));
                Signal(nameof(WorkList));
                Signal(nameof(EndList));
                Signal(nameof(ArchiveList));

            }, () =>
            {
                return true;
            });

            AddTaskCommand = new Command(async () => 
            {
                var statuses = await StatusClient.GetAll();
                EditTask edit = new EditTask(new BisnesTaskDTO(), 0, statuses);
                edit.ShowDialog();

            }, () => 
            {
               if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true; 
            });
            EditTaskCommand = new CommandWithParametr<BisnesTaskDTO>(async (parametr) => 
            {
                var statuses = await StatusClient.GetAll();
                EditTask edit = new EditTask(SelectedTask, SelectedTask.UserId, statuses);
                edit.ShowDialog();
            }, () => 
            {
                if (SelectedTask == null)
                    return false;
                else if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;

            });
            DeleteTaskCommand = new CommandWithParametr<BisnesTaskDTO>(async (parametr) => 
            { 
                var answ = await TaskClient.Delete(SelectedTask.Id);
                CheckResultAndGo(answ, SystemMessages.SuccessDelete);
            }, () => 
            {
                if (SelectedTask == null)
                    return false;
                else if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
            SaveCommand = new Command(async () => 
            {
                string answ;
                foreach(var task in PlaneList)
                {
                    task.IdStatus = 1;
                    answ = await TaskClient.UpdateTask(task);

                    if(answ != SystemMessages.SuccessUpdate)
                    {
                        MessageBox.Show($"Что-то пошло не так на {task.Author}: {task.Content}!");
                        return;
                    }
                }
                foreach(var task in WorkList)
                {
                    task.IdStatus = 5;
                    answ = await TaskClient.UpdateTask(task);

                    if(answ != SystemMessages.SuccessUpdate)
                    {
                        MessageBox.Show($"Что-то пошло не так на {task.Author}: {task.Content}!");
                        return;
                    }
                }
                foreach(var task in EndList)
                {
                    task.IdStatus = 6;
                    answ = await TaskClient.UpdateTask(task);

                    if(answ != SystemMessages.SuccessUpdate)
                    {
                        MessageBox.Show($"Что-то пошло не так на {task.Author}: {task.Content}!");
                        return;
                    }
                }
                MessageBox.Show("Все успешно сохранено!");
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
                //  answ = await TaskClient.UpdateTask(SelectedTask);
                // CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
            }, () => 
            {
                if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
            AddToArchiveCommand = new CommandWithParametr<BisnesTaskDTO>(async (parametr) => 
            {
                SelectedTask.IdStatus = 7;
                var answ = await TaskClient.UpdateTask(SelectedTask);
                CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
            }, () => 
            {
                if (SelectedTask == null)
                    return false;
                else if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
            ChangeArchStatusCommand = new CommandWithParametr<BisnesTaskDTO>(async (parametr) => 
            {
                SelectedTask.IdStatus = 6;
                var answ = await TaskClient.UpdateTask(SelectedTask);
                CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
            }, () => 
            {
                if (SelectedTask == null)
                    return false;
                else if (RoleId == UserClient.ghostUser.IdRole)
                    return false;
                else
                    return true;
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private static void CheckResultAndGo(string requestAnsw, string systemMessage)
        {
            if (requestAnsw == systemMessage)
            {
                MessageBox.Show(requestAnsw);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
            }
            else
            {
                MessageBox.Show(requestAnsw);
                return;
            }
        }

        private async void SetArchUserTask(short UserId)
        {
            var list = new ObservableCollection<BisnesTaskDTO>(await TaskClient.Get_FilterStatus_UsersTasks(UserId, 7) );
            SetTasks(list);
        }

        private async void SetArchAdminTasks()
        {
            var list = new ObservableCollection<BisnesTaskDTO>(await TaskClient.Get_FilterStatus_AllTasks(new DateTime(), new DateTime(), 7));
            SetTasks(list);
        }

        //standart
        private async void SetUserTask(short UserId, string searchTextBox)
        {
            var list = new ObservableCollection<BisnesTaskDTO>(await TaskClient.GetUsersTasks(UserId) );


            if (!string.IsNullOrEmpty(searchTextBox))
            {
                list = new ObservableCollection<BisnesTaskDTO>( list.Where(s => s.Author.ToLower().Contains(searchTextBox.ToLower()) | 
                                                                            s.Content.ToLower().Contains(searchTextBox.ToLower()) |
                                                                            s.AssignmentsContent.ToLower().Contains(searchTextBox.ToLower())) );
            }
            SetTasks(list);
        }

        private async void SetAdminTasks(string searchTextBox)
        {
            var list = new ObservableCollection<BisnesTaskDTO>(await TaskClient.GetAllTasks(new DateTime(), new DateTime()));

            if (!string.IsNullOrEmpty(searchTextBox))
            {
                list = new ObservableCollection<BisnesTaskDTO>( list.Where(s => s.Author.ToLower().Contains(searchTextBox) |
                                                                            s.Content.ToLower().Contains(searchTextBox) |
                                                                            s.AssignmentsContent.ToLower().Contains(searchTextBox)) );
            }

            SetTasks(list);
        }


        //заполнение задач
        private async void SetTasks(ObservableCollection<BisnesTaskDTO> list)
        {
           

            foreach (var task in list)
            {
                CheckPlaneStatus(task);
                CheckWorkStatus(task);
                CheckEndStatus(task);
                CheckArchiveStatus(task);
            }
        }

      

        private void CheckArchiveStatus(BisnesTaskDTO task)
        {
            if (task.IdStatus == 7)
                ArchiveList.Add(task);
        }

        private void CheckEndStatus(BisnesTaskDTO task)
        {
            if (task.IdStatus == 6)
                EndList.Add(task);
        }

        private void CheckWorkStatus(BisnesTaskDTO task)
        {
            if (task.IdStatus == 5)
                WorkList.Add(task);
        }

        private void CheckPlaneStatus(BisnesTaskDTO task)
        {
            if (task.IdStatus == 1)
                PlaneList.Add(task);
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
