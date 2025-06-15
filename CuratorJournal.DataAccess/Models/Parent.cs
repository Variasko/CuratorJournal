using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Parent
{
    public int ParentId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<IndividualWork> IndividualWorks { get; set; } = new List<IndividualWork>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
