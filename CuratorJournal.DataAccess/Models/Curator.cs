using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Curator
{
    public int CuratorId { get; set; }

    public int CategoryId { get; set; }

    public int UserId { get; set; }

    public virtual TeacherCategory Category { get; set; } = null!;

    public virtual ICollection<CuratorCharacteristic> CuratorCharacteristics { get; set; } = new List<CuratorCharacteristic>();

    public virtual Person CuratorNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}
