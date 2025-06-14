using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class StudentClassHourResponse
{
    public int ClassHourId { get; set; }
    public int StudentId { get; set; }
    public bool IsVisited { get; set; }
}
