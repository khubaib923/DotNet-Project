using FirstWebApplication.Data;
using FirstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebApplication.Controllers
{
    public class CategoryController : Controller
    {
        public ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<CategoryModel> category = _context.Category;
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}
