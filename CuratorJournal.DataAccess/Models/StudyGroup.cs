using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class StudyGroup
{
    public int StudyGroupId { get; set; }

    public string DirectionAbbreviation { get; set; } = null!;

    public string? SpecializationAbbreviation { get; set; }

    public int? Course { get; set; }

    public DateOnly DateCreate { get; set; }

    public bool IsBuget { get; set; }

    public string? FullName { get; set; }

    public bool IsStudyComplieted { get; set; }

    public virtual Direction DirectionAbbreviationNavigation { get; set; } = null!;

    public virtual ICollection<ParentMeeting> ParentMeetings { get; set; } = new List<ParentMeeting>();

    public virtual Specialization? SpecializationAbbreviationNavigation { get; set; }

    public virtual ICollection<Curator> Curators { get; set; } = new List<Curator>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
