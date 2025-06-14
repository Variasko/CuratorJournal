using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class ClassHourResponse
{
    public int ClassHourId { get; set; }
    public DateOnly Date { get; set; }
    public string Topic { get; set; }
    public string Decision { get; set; }
}
