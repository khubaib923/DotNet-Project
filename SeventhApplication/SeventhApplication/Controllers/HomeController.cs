using Microsoft.AspNetCore.Mvc;
using SeventhApplication.Models;

namespace SeventhApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //ViewData["ListTitle"] = "List Of Countries";
            //ViewData["country"] =new List<string>() { "Pakistan","India","China","Australia","America"};
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            ListModel model = new ListModel();

            return View(model);
        }
        [Route("data")]
        public IActionResult Data()
        {
            ListModel model = new ListModel()
            {
                ListItems = { "Karachi", "Islamabad", "Lahore", "Multan", "Sultan" },
                ListTitle="Countries"
            };
            return PartialView("_ListPartial",model);
        }
    }
}
