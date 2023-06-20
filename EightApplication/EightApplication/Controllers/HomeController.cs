using EightApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace EightApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("griddata")]
        public IActionResult GridData()
        {
            PersonGrid grid = new PersonGrid()
            {
                GridTitle = "Person List",
                Persons = new List<Person>()
                {
                    new Person() {JobTitle="Manager",PersonName="yasir"},
                    new Person() {JobTitle="Ass.Manager",PersonName="nuhail"},
                    new Person() {JobTitle="Director",PersonName="Qadir"},
                }
            };
            return ViewComponent("Grid",new { personGrid = grid});
        }
    }
}
