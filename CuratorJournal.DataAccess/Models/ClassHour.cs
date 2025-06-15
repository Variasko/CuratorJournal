using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class ClassHour
{
    public int ClassHourId { get; set; }

    public DateOnly Date { get; set; }

    public string Topic { get; set; } = null!;

    public string Decision { get; set; } = null!;

    public virtual ICollection<StudentClassHour> StudentClassHours { get; set; } = new List<StudentClassHour>();
}
