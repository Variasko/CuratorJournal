using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class StudyGroupResponse
{
    public int StudyGroupId { get; set; }
    public string SpecificationAbbreviation { get; set; }
    public string? QualificationAbbreviation { get; set; }
    public int Course { get; set; }
    public DateOnly DateCreate { get; set; }
    public bool IsBuget { get; set; }
    public string? FullName { get; set; }
}
