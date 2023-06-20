using Microsoft.AspNetCore.Mvc;

namespace SixthApplication.Controllers
{
    public class ProductController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("search/{id?}")]
        public IActionResult Search(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        [Route("Order")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
