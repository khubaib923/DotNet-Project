using Microsoft.AspNetCore.Mvc;

namespace FifthApplication.Controllers
{
    public class ProductController : Controller
    {
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
        }
    }
}
