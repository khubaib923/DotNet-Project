namespace CascadingDropdown.Models
{
    public class CityModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public CountryModel? Country { get; set; }
    }
}
