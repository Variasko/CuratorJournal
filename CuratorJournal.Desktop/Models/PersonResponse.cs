using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class PersonResponse
{
    public int PersonId { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string PassportSerial { get; set; }
    public string PassportNumber { get; set; }
    public string WhoGavePassport { get; set; }
    public DateOnly WhenGetPassport { get; set; }
    public string INN { get; set; }
    public string SNILS { get; set; }
    public byte[]? Photo { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
}
