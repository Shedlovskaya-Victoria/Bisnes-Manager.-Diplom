using System;
using System.Collections.Generic;

namespace BisnesManager.DatabasePersistens.Model;

public partial class BisnesTask
{
    public int Id { get; set; }

    public short IdUser { get; set; }

    public string Content { get; set; } = null!;

    public int? Indentation { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? AssignmentsContent { get; set; }

    public short IdStatus { get; set; }

    public DateOnly DateCreate { get; set; }

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
