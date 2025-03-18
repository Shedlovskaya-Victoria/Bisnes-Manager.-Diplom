using System;
using System.Collections.Generic;

namespace BisnesManager.Database.Models;

public partial class User
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public string Family { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string CheckPhrase { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Login { get; set; } = null!;

    public short IdRole { get; set; }

    public byte[]? PhotoImage { get; set; }

    public DateOnly StartWorkTime { get; set; }

    public DateOnly DateCreate { get; set; }

    public DateOnly? EndWorkTime { get; set; }

    public virtual ICollection<BisnesTask> BisnesTasks { get; set; } = new List<BisnesTask>();

    public virtual ICollection<HolidayPlan> HolidayPlans { get; set; } = new List<HolidayPlan>();

    public virtual UserRole IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Statistic> Statistics { get; set; } = new List<Statistic>();
}
