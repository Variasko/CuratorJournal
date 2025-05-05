using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public int CuratorId { get; set; }

    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual Curator Curator { get; set; } = null!;
}
