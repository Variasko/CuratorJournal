using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class ParentMeeting
{
    public int MeetingId { get; set; }

    public int StudyGroupId { get; set; }

    public int Visited { get; set; }

    public int NotVisitedWithReason { get; set; }

    public int NotVisited { get; set; }

    public string Topic { get; set; } = null!;

    public string Decision { get; set; } = null!;

    public virtual StudyGroup StudyGroup { get; set; } = null!;
}
