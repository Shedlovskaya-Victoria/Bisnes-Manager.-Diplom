﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BisnesManager.Client.Tools;

namespace BisnesManager.Client.Model
{
    public class TimeTable
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public int Mounth { get; set; }
        public int Recycling { get; set; }
        public int AllHour { get; set; }
        public int WorkHour { get; set; }
        public int Day1 { get; set; }
        public int Day2 { get; set; }
        public int Day3 { get; set; }
        public int Day4 { get; set; }
        public int Day5{ get; set; }
        public int Day6 { get; set; }
        public int Day7 { get; set; }
        public int Day8 { get; set; }
        public int Day9 { get; set; }
        public int Day10 { get; set; }
        public int Day11 { get; set; }
        public int Day12 { get; set; }
        public int Day13 { get; set; }
        public int Day14 { get; set; }
        public int Day15 { get; set; }
        public int Day16 { get; set; }
        public int Day17 { get; set; }
        public int Day18 { get; set; }
        public int Day19 { get; set; }
        public int Day20 { get; set; }
        public int Day21 { get; set; }
        public int Day22 { get; set; }
        public int Day23 { get; set; }
        public int Day24 { get; set; }
        public int Day25 { get; set; }
        public int Day26 { get; set; }
        public int Day27 { get; set; }
        public int Day28 { get; set; }
        public int Day29 { get; set; }
        public int Day30{ get; set; }
        public int Day31 { get; set; }
    }
    public class TimeTableFebruary
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public int Mounth { get; set; }
        public int Recycling { get; set; }
        public int AllHour { get; set; }
        public int WorkHour { get; set; }
        public int Day1 { get; set; }
        public int Day2 { get; set; }
        public int Day3 { get; set; }
        public int Day4 { get; set; }
        public int Day5{ get; set; }
        public int Day6 { get; set; }
        public int Day7 { get; set; }
        public int Day8 { get; set; }
        public int Day9 { get; set; }
        public int Day10 { get; set; }
        public int Day11 { get; set; }
        public int Day12 { get; set; }
        public int Day13 { get; set; }
        public int Day14 { get; set; }
        public int Day15 { get; set; }
        public int Day16 { get; set; }
        public int Day17 { get; set; }
        public int Day18 { get; set; }
        public int Day19 { get; set; }
        public int Day20 { get; set; }
        public int Day21 { get; set; }
        public int Day22 { get; set; }
        public int Day23 { get; set; }
        public int Day24 { get; set; }
        public int Day25 { get; set; }
        public int Day26 { get; set; }
        public int Day27 { get; set; }
        public int Day28 { get; set; }
    }
    public class TimeTable30DaysInMouth : Base
    {
        private int day7;

        public int ID { get; set; }
        public string FIO { get; set; }
        public int Mounth { get; set; }
        public int Recycling { get; set; }
        public int AllHour { get; set; }
        public int WorkHour { get; set; }
        public int Day1 { get; set; }
        public int Day2 { get; set; }
        public int Day3 { get; set; }
        public int Day4 { get; set; }
        public int Day5{ get; set; }
        public int Day6 { get; set; }
        public int Day7 { get => day7;
            set
            {
                day7 = value;
                Signal();
            }
        }
        public int Day8 { get; set; }
        public int Day9 { get; set; }
        public int Day10 { get; set; }
        public int Day11 { get; set; }
        public int Day12 { get; set; }
        public int Day13 { get; set; }
        public int Day14 { get; set; }
        public int Day15 { get; set; }
        public int Day16 { get; set; }
        public int Day17 { get; set; }
        public int Day18 { get; set; }
        public int Day19 { get; set; }
        public int Day20 { get; set; }
        public int Day21 { get; set; }
        public int Day22 { get; set; }
        public int Day23 { get; set; }
        public int Day24 { get; set; }
        public int Day25 { get; set; }
        public int Day26 { get; set; }
        public int Day27 { get; set; }
        public int Day28 { get; set; }
        public int Day29 { get; set; }
        public int Day30 { get; set; }
    }
}
