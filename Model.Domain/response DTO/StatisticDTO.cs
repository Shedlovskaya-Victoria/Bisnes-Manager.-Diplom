﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.DTO
{
    public class StatisticDTO
    { 
        public int UserId { get; set; }
        public int QualityWork { get; set; }

        public int LevelResponibility { get; set; }


        public int HardSkils { get; set; }

        public int SoftSkils { get; set; }

        public DateOnly DateCreate { get; set; }
    }
}
