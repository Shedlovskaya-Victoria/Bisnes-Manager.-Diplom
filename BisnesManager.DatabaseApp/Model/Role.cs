using System;
using System.Collections.Generic;

namespace BisnesManager.DatabasePersistens.Model;

public partial class Role
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public bool IsEditWorkersRoles { get; set; }

    public bool IsEditWorkTimeTable { get; set; }

    public string? Post { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
