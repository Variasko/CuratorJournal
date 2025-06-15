using System.Collections.Generic;

namespace CuratorJournal.Desktop.Models;

public class UserResponse
{
    public int UserId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}
