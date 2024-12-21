using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Domain.DTO
{
    public class Statistic
    {
        public int Id { get; set; }

        public short IdUser { get; set; }

        public DateOnly Date { get; set; }

        public int QualityWork { get; set; }

        public int LevelResponibility { get; set; }

        public int EffectivCommunication { get; set; }

        public int HardSkils { get; set; }

        public int SoftSkils { get; set; }
    }
}
