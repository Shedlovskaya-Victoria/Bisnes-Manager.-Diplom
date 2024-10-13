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
using Система_учета_сотрудников._Дипломный_проект.Model;

namespace Система_учета_сотрудников._Дипломный_проект.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для EditWorkers.xaml
    /// </summary>
    public partial class EditWorkers : UserControl
    {
        public string PageTitle { get; set; } = "Редактирование сотрудников";
        public List<Worker> WorkersList { get; set; }
        public EditWorkers()
        {
            InitializeComponent();
            WorkersList = new List<Worker>()
            {
                new Worker(){ Id = 1, Name = "Name 1"},
                new Worker(){ Id = 2, Name = "Name 2"},
                new Worker(){ Id = 3, Name = "Name 3"},
                new Worker(){ Id = 4, Name = "Name 4"},
                new Worker(){ Id = 5, Name = "Name 5"},
                new Worker(){ Id = 6, Name = "Name 6"},
            };
        }
    }
}
