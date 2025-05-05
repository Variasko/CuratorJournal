using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Language
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Translation> Translations { get; set; } = new List<Translation>();
}
