using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Система_учета_сотрудников._Дипломный_проект.Model
{
    public class WeekendsTablePlan
    {
        public DateTime StartDayWeek { get; set; }
        public DateTime EndDayWeek { get; set; }
        public string FIO {  get; set; }

        [NotMapped]
        public uint PercentOutWorkPeople { get; set; }


        [NotMapped]
        public uint[] WeekInMount { get; set; }
        [NotMapped]
        public uint LenghtWeekends { get; set; }
    }
  
}
