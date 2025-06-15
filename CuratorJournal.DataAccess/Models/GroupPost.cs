using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class GroupPost
{
    public int PostId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
