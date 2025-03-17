using System;
using System.Collections.Generic;

namespace BisnesManager.Database.Models;

public partial class Status
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<BisnesTask> BisnesTasks { get; set; } = new List<BisnesTask>();
}
