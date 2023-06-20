namespace EightApplication.Models
{
    public class PersonGrid
    {
        public string GridTitle { get; set; } = string.Empty;
        public List<Person> Persons { get; set; } = new List<Person>();
    }
}
