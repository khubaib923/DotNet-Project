namespace CascadingDropdown.Models
{
    public class AreaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public CityModel? City { get; set; }
    }
}
