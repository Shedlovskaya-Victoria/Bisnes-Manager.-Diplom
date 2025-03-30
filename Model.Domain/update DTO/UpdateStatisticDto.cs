using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.update_DTO
{
    public class UpdateStatisticDto
    {
        public int Id { get; set; }
        public short IdUser { get; set; }

        public int QualityWork { get; set; }

        public int LevelResponibility { get; set; }

        public int EffectivCommunication { get; set; }

        public int HardSkils { get; set; }

        public int SoftSkils { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
