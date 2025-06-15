using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Qualification
{
    public string Abbreviation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}
