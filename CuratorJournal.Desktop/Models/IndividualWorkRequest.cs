namespace CuratorJournal.Desktop.Models;

public class IndividualWorkRequest
{
    public bool IsStudent { get; set; }
    public string Topic { get; set; }
    public string Decision { get; set; }
    public DateOnly Date { get; set; }
}
