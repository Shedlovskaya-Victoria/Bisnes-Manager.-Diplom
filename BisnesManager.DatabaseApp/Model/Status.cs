﻿using System;
using System.Collections.Generic;

namespace BisnesManager.DatabasePersistens.Model;

public partial class Status
{
    public short Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
