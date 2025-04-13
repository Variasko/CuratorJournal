namespace CuratorJournal.Desktop.Models
{
    internal class Person
    {
        public int PersonId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public byte[] Photo { get; set; } = null;
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
