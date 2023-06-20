using Microsoft.AspNetCore.Mvc;

namespace TenthApplication.Controllers
{
    public class HomeController : Controller
    {

        public readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("/")]
        public IActionResult Index()
        {
            string path = _webHostEnvironment.ContentRootPath;
            ViewBag.isCheck=_webHostEnvironment.IsDevelopment();
            ViewBag.currentEnvironment = _webHostEnvironment.EnvironmentName;
            return View();
        }
        [Route("/home")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
