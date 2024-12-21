using System;
using System.Collections.Generic;

namespace BisnesManager.DatabasePersistens.Model;

public partial class HolidayPlan
{
    public int Id { get; set; }

    public short IdUser { get; set; }

    public DateOnly Date { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
