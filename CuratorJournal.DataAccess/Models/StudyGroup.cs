using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class StudyGroup
{
    public int StudyGroupId { get; set; }

    public string SpecificationAbbreviation { get; set; } = null!;

    public string? QualificationAbbreviation { get; set; }

    public int Course { get; set; }

    public DateOnly DateCreate { get; set; }

    public bool IsBuget { get; set; }

    public string? FullName { get; set; }

    public virtual ICollection<ParentMeeting> ParentMeetings { get; set; } = new List<ParentMeeting>();

    public virtual Qualification? QualificationAbbreviationNavigation { get; set; }

    public virtual Specification SpecificationAbbreviationNavigation { get; set; } = null!;

    public virtual ICollection<Curator> Curators { get; set; } = new List<Curator>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
