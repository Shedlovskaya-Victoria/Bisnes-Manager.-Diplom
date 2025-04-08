using System;
using System.Collections.Generic;

namespace BisnesManager.Database.Models;

public partial class UserRole
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsEditWorkersRoles { get; set; }

    public bool IsShowDiagramStatistic { get; set; }

    public string? Post { get; set; }

    public DateOnly DateCreate { get; set; }

    public bool? IsUse { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
