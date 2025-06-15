using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class TeacherCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Curator> Curators { get; set; } = new List<Curator>();
}
