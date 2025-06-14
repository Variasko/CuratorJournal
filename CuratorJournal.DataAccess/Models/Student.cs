using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public bool? IsDeduction { get; set; }

    public DateOnly DateDeduction { get; set; }

    public virtual ICollection<CuratorCharacteristic> CuratorCharacteristics { get; set; } = new List<CuratorCharacteristic>();

    public virtual ICollection<IndividualWork> IndividualWorks { get; set; } = new List<IndividualWork>();

    public virtual ICollection<StudentClassHour> StudentClassHours { get; set; } = new List<StudentClassHour>();

    public virtual ICollection<StudentInDormitory> StudentInDormitories { get; set; } = new List<StudentInDormitory>();

    public virtual Person StudentNavigation { get; set; } = null!;

    public virtual ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();

    public virtual ICollection<Parent> Parents { get; set; } = new List<Parent>();

    public virtual ICollection<GroupPost> Posts { get; set; } = new List<GroupPost>();

    public virtual ICollection<SocialStatus> SocialStatuses { get; set; } = new List<SocialStatus>();

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}
