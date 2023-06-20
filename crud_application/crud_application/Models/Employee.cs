namespace crud_application.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Designation { get; set; } = string.Empty;
        public int Salary { get; set; }
        public Gender Gender { get; set; }
        public string Married { get; set; } = string.Empty;




    }

    public enum Gender
    {
        MALE,
        FEMALE,
    }
}
