using CascadingDropdown.Data;
using Microsoft.AspNetCore.Mvc;

namespace CascadingDropdown.Controllers
{
    public class CascadingController : Controller
    {
        public ApplicationDbContext _context;
        public CascadingController(ApplicationDbContext context)
        {

            _context = context;
        }

        public JsonResult GetAllCountries()
        {
            var data = _context.Countries.ToList();
            return Json(data);
        }

        public JsonResult GetAllCities(int id)
        {
            var data = _context.Cities.Where(e => e.Country!.Id == id).ToList();
            return Json(data);
        }

        public JsonResult GetAllAreas(int id)
        {
            var data = _context.Areas.Where(e => e.City!.Id == id).ToList();
            return Json(data);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
