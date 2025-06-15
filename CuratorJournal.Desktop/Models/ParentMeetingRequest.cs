namespace CuratorJournal.Desktop.Models;

public class ParentMeetingRequest
{
    public int Visited { get; set; }
    public int NotVisitedWithReason { get; set; }
    public int NotVisited { get; set; }
    public string Topic { get; set; }
    public string Decision { get; set; }
}
