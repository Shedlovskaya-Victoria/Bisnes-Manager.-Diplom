using BisnesManager.Client.Tools;
using BisnesManager.Client.View;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.Mapper;
using BisnesManager.ETL.request_DTO;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Система_учета_сотрудников._Дипломный_проект.Tools;
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace Система_учета_сотрудников._Дипломный_проект.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditTask.xaml
    /// </summary>
    /// 
    public partial class EditTask : Window, INotifyPropertyChanged
    {
        private StatusDTO selectedStatus;
        private BisnesTaskDTO task;

        public BisnesTaskDTO Task { 
            get => task;
            set
            {
                task = value;
                Signal();
            }
        }

        public IEnumerable<StatusDTO> Statuses {  get; set; }
        public StatusDTO SelectedStatus { get => selectedStatus;
            set
            {
                selectedStatus = value;
                if(value!=null)
                {
                    if(value.Id!=0)
                        Task.IdStatus = value.Id;
                }
                Signal();
            }
        }

        public Command SaveCommand { get; set; }
        public Command BackCommand { get; set; }

        public EditTask(BisnesTaskDTO taskDTO, int id, IEnumerable<StatusDTO> statuses)
        {
            InitializeComponent();
            Task = taskDTO;
            Statuses = statuses;
            if (id == 0)
            {
                Task.IdStatus = 1;
                SelectedStatus = Statuses.FirstOrDefault(s => s.Id == 1);
                Task.StartDate = DateTime.Now;
                Task.EndDate = DateTime.Now.AddDays(5);
                Task.Indentation = 0;
            }
            else
            {
                SelectedStatus = Statuses.FirstOrDefault(s => s.Id == Task.IdStatus);
            }
            DataContext = this;

            SaveCommand = new Command(async () =>
            {

                if (id == 0)
                {
                    var task = Task.ToCreateDto();
                    task.IdUser = UserClient.user.Id;
                    var asnw = await TaskClient.CreateTask(task);
                    var flag = CheckResultAndGo(asnw, SystemMessages.SuccesSave);
                    if(flag)
                        Close();
                }
                else
                {
                    var answ = await TaskClient.UpdateTask(Task.ToUpdateDTO(), id);
                    var flag = CheckResultAndGo(answ, SystemMessages.SuccessUpdate);
                    if(flag)
                     Close();
                }


            }, () =>
            {
                if (Task.IdStatus == 0)
                {
                     MessageBox.Show("Выберите статус!");
                    return false;
                }
                else if (Task.EndDate == new DateTime())
                {
                    return false;
                }
                else if (Task.StartDate == new DateTime())
                {
                    return false;
                }
                else if (string.IsNullOrEmpty(Task.Content))
                {
                    return false;
                }
                else
                    return true;
            });
            BackCommand = new Command(() =>
            {
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
                Close();
            }, () =>
            {
                return true;
            });
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        private static bool CheckResultAndGo(string requestAnsw, string systemMessage)
        {
            if (requestAnsw == systemMessage)
            {
                MessageBox.Show(requestAnsw);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
                return true;
            }
            else
            {
                MessageBox.Show(requestAnsw);
                return false;
            }
        }

    }
}
