using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class ParentMeetingResponse
{
    public int MeetingId { get; set; }
    public int StudyGroupId { get; set; }
    public int Visited { get; set; }
    public int NotVisitedWithReason { get; set; }
    public int NotVisited { get; set; }
    public string Topic { get; set; }
    public string Decision { get; set; }
}
