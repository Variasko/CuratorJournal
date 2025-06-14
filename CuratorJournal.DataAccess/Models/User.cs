using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }

    public virtual ICollection<Curator> Curators { get; set; } = new List<Curator>();
}
