using System;
using System.Collections.Generic;

namespace CuratorJournal.DataAccess.Models;

public partial class CuratorCharacteristic
{
    public int CharacteristicId { get; set; }

    public int StudentId { get; set; }

    public int CuratorId { get; set; }

    public string Characteristic { get; set; } = null!;

    public DateOnly DateCreated { get; set; }

    public virtual Curator Curator { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
