using BisnesManager.ETL.DTO;
using DlhSoft.Windows.Controls;
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

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для DiagramGant.xaml
    /// </summary>
    public partial class DiagramGant : UserControl
    {
        public DiagramGant(IEnumerable<BisnesTaskDTO> tasks)
        {
            InitializeComponent();

            DataContext = this;

            //диаграмма ганта
            //загрузить и представить элементы данных в GanttChartDataGrid

            if(tasks == null)
            {
                var item1 = new GanttChartItem { Content = "My summary task" };
                var item2 = new GanttChartItem
                {
                    Content = "My standard task",
                    Indentation = 1,
                    Start = DateTime.Today,
                    Finish = DateTime.Today.AddDays(5),
                    CompletedFinish = DateTime.Today.AddDays(3),
                    AssignmentsContent = "My resource"
                };
                var item3 = new GanttChartItem
                {
                    Content = "My milestone",
                    Indentation = 1,
                    IsMilestone = true
                };
                GanttChartDataGrid.Items = new ObservableCollection<GanttChartItem> { item1, item2, item3 };
            }
            else
            {
                foreach (var task in tasks)
                {
                    GanttChartDataGrid.Items.Add(new GanttChartItem()
                    {
                        Content = task.Content,
                        Indentation = (int)task.Indentation,
                        Start = task.StartDate,
                        Finish = task.EndDate,
                        AssignmentsContent = task.AssignmentsContent,
                        ItemHeight = 100,
                        
                    });
                }
            }

          

        }
    }
}
