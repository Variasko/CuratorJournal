using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class StudentInDormitory
{
    public int StudentId { get; set; }

    public int Room { get; set; }

    public virtual Student Student { get; set; } = null!;
}
