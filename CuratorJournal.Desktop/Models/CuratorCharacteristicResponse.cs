using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class CuratorCharacteristicResponse
{
    public int CharacteristicId { get; set; }
    public int StudentId { get; set; }
    public int CuratorId { get; set; }
    public string Characteristic { get; set; }
    public DateOnly DateCreated { get; set; }
}
