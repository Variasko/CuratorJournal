using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class IndividualWork
{
    public int IndividualWorkId { get; set; }

    public bool IsStudent { get; set; }

    public int? StudentId { get; set; }

    public int? ParentId { get; set; }

    public string Topic { get; set; } = null!;

    public string Decision { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual Parent? Parent { get; set; }

    public virtual Student? Student { get; set; }
}
