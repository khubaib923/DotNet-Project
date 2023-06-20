using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using youtube_tutorial.Models;

namespace youtube_tutorial.Controllers
{
    //[Route("[controller]/[action]/[{age}]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        public IActionResult Index()
        {
            CategoryModel c1=new CategoryModel();
            c1.Age = 22;
            c1.Name = "khubaib";
            c1.Id = 1;

            CategoryModel c2 = new CategoryModel();
            c2.Age = 22;
            c2.Name = "khubaib";
            c2.Id = 1;

            CategoryModel c3 = new CategoryModel();
            c3.Age = 22;
            c3.Name = "khubaib";
            c3.Id = 1;

            List<CategoryModel> c = new List<CategoryModel>() { c1,c2,c3};
           


            return View(c);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public int FindAge(int age)
        {
            return age;
        }
        public IActionResult Contact() { 
        return View();
        
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}