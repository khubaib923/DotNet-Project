namespace FifthApplication.Models
{
    public class Person
    {
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? MyGender { get; set; } 
    }
    public enum Gender { male, female, other }
}
