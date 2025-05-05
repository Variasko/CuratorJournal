using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string PassportSerial { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string WhoGavePassport { get; set; } = null!;

    public DateOnly WhenGetPassport { get; set; }

    public string Inn { get; set; } = null!;

    public string Snils { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual Curator? Curator { get; set; }

    public virtual Student? Student { get; set; }
}
