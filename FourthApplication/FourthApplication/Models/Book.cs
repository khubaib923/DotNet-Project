using Microsoft.AspNetCore.Mvc;

namespace FourthApplication.Models
{
    public class Book
    {
        //[FromQuery]

        public int? BookId { get; set; }

        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book id are:{BookId},Author are:{Author}";
        }
    }
}
