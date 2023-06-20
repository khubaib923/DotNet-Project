using Microsoft.AspNetCore.Mvc;
using FourthApplication.Models;
using Microsoft.JSInterop.Implementation;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using FourthApplication.Model_Binders;

namespace FourthApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("bookstore/{BookId?}/{Loggedin?}")]
        public IActionResult Index([FromQuery]int? BookId,bool? Loggedin,Book book)
        {

           //if (bookid.HasValue == false) { } 
           return Content(book.ToString());
        }

        [Route("Person")]
        public IActionResult About(/*[ModelBinder(BinderType =typeof(CustomModelBinder))]*/ Person person,[FromHeader(Name ="User-Agent")]string userAgent)
        {
            //[Bind(nameof(Person.PersonName), nameof(Person.Password), "ConfirmPassword")]
            if (!ModelState.IsValid)
            {
                List<String> errorList = new List<String>();
                //foreach(var value in ModelState.Values)
                //{
                //    foreach(var error in value.Errors)
                //    {
                //        errorList.Add(error.ErrorMessage);
                //    }
                //}
               
                string errors=string.Join("\n",ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                //string errors = string.Join("\n",errorList);
                errorList.Add(errors);
                return BadRequest(errors);
            }
            return Content(person.ToString());

        }
    }
}
