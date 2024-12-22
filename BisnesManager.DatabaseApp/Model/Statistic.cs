using System;
using System.Collections.Generic;

namespace BisnesManager.DatabasePersistens.Model;

public partial class Statistic
{
    public int Id { get; set; }

    public short IdUser { get; set; }

    public int QualityWork { get; set; }

    public int LevelResponibility { get; set; }

    public int EffectivCommunication { get; set; }

    public int HardSkils { get; set; }

    public int SoftSkils { get; set; }

    public DateOnly DateCreate { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
