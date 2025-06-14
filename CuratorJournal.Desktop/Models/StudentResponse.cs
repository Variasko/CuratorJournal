namespace CuratorJournal.Desktop.Models;

public class StudentResponse
{
    public int StudentId { get; set; }
    public bool? IsDeduction { get; set; }
    public DateOnly DateDeduction { get; set; }
}
