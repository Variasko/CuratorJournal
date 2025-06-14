namespace CuratorJournal.Desktop.Models;

public class StudyGroupRequest
{
    public string SpecificationAbbreviation { get; set; }
    public string? QualificationAbbreviation { get; set; }
    public int Course { get; set; }
    public DateOnly DateCreate { get; set; }
    public bool IsBuget { get; set; }
    public string? FullName { get; set; }
}
