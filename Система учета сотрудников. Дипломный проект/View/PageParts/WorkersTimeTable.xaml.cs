using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

namespace BisnesManager.Client.View.PageParts
{
    /// <summary>
    /// Логика взаимодействия для WorkersTimeTable.xaml
    /// </summary>
    public partial class WorkersTimeTable : UserControl, INotifyPropertyChanged
    {
        public bool ChangeColor { get; set; }

        private double _Bid;
        public double Bid
        {
            get { return _Bid; }
            set
            {
                if(_Bid == 0)//, change fore color
                 ChangeColor = true;
                _Bid = value;
            }
        }
        public List<TimeTable> TimeTables { get; set; }
        public string Title { get; set; } 
        public WorkersTimeTable()
        {
            InitializeComponent();

            Title = $"Рабочее расписание месяца {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(9)}";

            TimeTables = new List<TimeTable>();
            Random random = new Random();

            for (int i = 1; i <= 10; i++)
            {
                TimeTable t = new TimeTable();

                t.ID = i;
                t.FIO = $"Маша {i}";
                t.Mounth = 9;
                t.Recycling = random.Next(0, 20);
                t.WorkHour = random.Next(6, 8);
                t.Day1 = random.Next(2,8);
                t.Day2 = random.Next(2,8);
                t.Day3 = random.Next(2,8);
                t.Day4 = random.Next(2,8);
                t.Day5 = random.Next(2,8);
                t.Day6 = random.Next(2,8);
                t.Day7 = 0;  Bid = 0;
                t.Day8 = 0;
                t.Day9 = random.Next(2,8);
                t.Day10 = random.Next(2,8);
                t.Day11 = random.Next(2,8);
                t.Day12 = random.Next(2,8);
                t.Day13 = random.Next(2,8);
                t.Day14 = 0;
                t.Day15 = 0;
                t.Day16 = random.Next(2,8);
                t.Day17 = random.Next(2,8);
                t.Day18 = random.Next(2,8);
                t.Day19 = random.Next(2,8);
                t.Day20 = random.Next(2,8);
                t.Day21 = random.Next(4,8);
                t.Day22 = random.Next(5,8);
                t.Day23 = random.Next(6,8);
                t.Day24 = 0;
                t.Day25 = 0;
                t.Day26 = random.Next(7,8);
                t.Day27 = random.Next(1,8);
                t.Day28 = random.Next(1,8);
                t.Day29 = random.Next(1,8);
                t.Day30 = 0;
                t.Day31 = 0;
                t.AllHour = t.Day1 + t.Day2 + t.Day3 + t.Day4 + t.Day5 + t.Day6 + t.Day7 + t.Day7 + t.Day7 + t.Day8 + t.Day8 + t.Day9 + t.Day10 + t.Day11 + t.Day12 + t.Day13 + t.Day14 + t.Day15 + t.Day16 + t.Day17 + t.Day18 + t.Day18 + t.Day19 + t.Day20 + t.Day21 + t.Day22 + t.Day23 + t.Day24 + t.Day25 + t.Day26 + t.Day27 + t.Day28 + t.Day29 + t.Day30 + t.Day31 + t.Recycling;
            
                TimeTables.Add(t);        
            }

          
            DataContext = this;
            Signal(nameof(Title));
            Signal(nameof(TimeTables));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
