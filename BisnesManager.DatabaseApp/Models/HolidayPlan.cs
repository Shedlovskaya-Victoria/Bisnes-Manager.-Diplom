using System;
using System.Collections.Generic;

namespace BisnesManager.Database.Models;

public partial class HolidayPlan
{
    public int Id { get; set; }

    public short IdUser { get; set; }

    public DateOnly DateCreate { get; set; }

    public DateOnly StartWeekends { get; set; }

    public DateOnly EndWeekends { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
