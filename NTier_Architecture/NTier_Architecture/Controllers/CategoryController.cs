using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using NTier_Architecture.Data;
using NTier_Architecture.Models;

namespace NTier_Architecture.Controllers
{
    public class CategoryController : Controller
    {
        public ApplicationDbContext _context;
        public IUnitOfWork _unitofwork;

        public CategoryController(ApplicationDbContext context, IUnitOfWork unitofwork)
        {
            _context = context;
            _unitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            //IEnumerable<CategoryModel> category = _context.Category;
            IEnumerable<CategoryModel>category=_unitofwork.CategoryRepository.GetAll();
            return View(category);
        }

        public IActionResult CreateUpdate(int? id)
        {

            if(id == null || id==0)
            {
                return View();
            }
            else
            {
                var category = _unitofwork.CategoryRepository.GetT(x => x.Id == id);
                return View(category);
            }
            
        }
        [HttpPost]
        public IActionResult CreateUpdate(CategoryModel categoryModel)
        {
            var id=categoryModel.Id;
            if(categoryModel.Id==0)
            {

                if(ModelState.IsValid)
                {

                    _unitofwork.CategoryRepository.Add(categoryModel);
                   
                }
                

            }
            else
            {
                if (ModelState.IsValid)
                {
                    _unitofwork.CategoryRepository.Update(categoryModel);
                    
                }
            }
            
            
            _unitofwork.Save();
            TempData["success"] = id == 0 ? "Categories Add" : "Categories Update";
            TempData.Peek("success");
            return RedirectToAction("Index");
         
            
            
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == 0 || id == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        //var category = _context.Category.Find(id);
        //        var category = _unitofwork.CategoryRepository.GetT(x=>x.Id==id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return View(category);
        //        }

        //    }
        //}
        //[HttpPost]
        //public IActionResult Edit(CategoryModel category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //_context.Category.Update(category);
        //        _unitofwork.CategoryRepository.Update(category);
        //        _context.SaveChanges();
        //        TempData["success"] = "Categories Updated Done!";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}
        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == 0 || id == null)
            {
                return NotFound();
            }
            else
            {
                //var category = _context.Category.Find(id);
                var category = _unitofwork.CategoryRepository.GetT(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }
            }




        }

        [HttpPost, ActionName("Delete")]


        public IActionResult DeleteData(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                //var category = _context.Category.Find(id);
                var category = _unitofwork.CategoryRepository.GetT(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    //_context.Category.Remove(category);
                    _unitofwork.CategoryRepository.Delete(category);
                    _context.SaveChanges();
                    TempData["success"] = "Categories Deleted Done!";
                    return RedirectToAction("Index");
                }

            }
        }

    }
}
