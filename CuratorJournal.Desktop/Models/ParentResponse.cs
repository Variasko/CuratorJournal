using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class ParentResponse
{
    public int ParentId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
