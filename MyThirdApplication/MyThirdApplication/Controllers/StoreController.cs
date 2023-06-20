using Microsoft.AspNetCore.Mvc;

namespace MyThirdApplication.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books/{id}")]
       public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h2>Redirect to store books {id}</h2>","text/html");
        }
    }
}
