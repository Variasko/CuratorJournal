using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class StudentClassHour
{
    public int ClassHourId { get; set; }

    public int StudentId { get; set; }

    public bool IsVisited { get; set; }

    public virtual ClassHour ClassHour { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
