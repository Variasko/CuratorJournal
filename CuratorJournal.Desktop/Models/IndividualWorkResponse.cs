using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class IndividualWorkResponse
{
    public int IndividualWorkId { get; set; }
    public bool IsStudent { get; set; }
    public int? StudentId { get; set; }
    public int? ParentId { get; set; }
    public string Topic { get; set; }
    public string Decision { get; set; }
    public DateOnly Date { get; set; }
}
