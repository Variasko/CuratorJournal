using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Specialization
{
    public string Abbreviation { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}
