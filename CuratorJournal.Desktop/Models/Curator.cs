namespace CuratorJournal.Desktop.Models
{
    internal class Curator
    {
        public int CuratorId { get; set; }
        public string CategoryName { get; set; }
        public List<Group> Groups { get; set; }
        public Person Person { get; set; }
    }
}
