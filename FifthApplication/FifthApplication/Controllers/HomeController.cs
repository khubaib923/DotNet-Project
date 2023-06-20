using FifthApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FifthApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/home")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.net core mvc";

            List<Person> personList = new List<Person>()
    {
        new Person()
        {
            Name="Altaf",
            DateOfBirth=Convert.ToDateTime("2004-09-23"),
            MyGender=Gender.male
        },
         new Person()
        {
            Name="Hussain",
            DateOfBirth=Convert.ToDateTime("2007-09-23"),
            MyGender=Gender.female
        },
         new Person()
        {
            Name="Khubaib",
            DateOfBirth=Convert.ToDateTime("2006-09-23"),
            MyGender=Gender.other
        }
    };
            //ViewData["person"] = personList;
            ViewBag.person = personList;

            return View("Index", personList);  //View/Home/Index   // View/Shared/Index
        }

        [Route("/persondetails/{name?}")]
        public IActionResult Details(string? name)
        {
            if (name == null)
            {
                return Content("Name can not be null");
            }
            List<Person> personList = new List<Person>()
    {
        new Person()
        {
            Name="Altaf",
            DateOfBirth=Convert.ToDateTime("2004-09-23"),
            MyGender=Gender.male
        },
         new Person()
        {
            Name="Hussain",
            DateOfBirth=Convert.ToDateTime("2007-09-23"),
            MyGender=Gender.female
        },
         new Person()
        {
            Name="Khubaib",
            DateOfBirth=Convert.ToDateTime("2006-09-23"),
            MyGender=Gender.other
        }
    };

            Person? person = personList.Where(x => x.Name == name).FirstOrDefault();
            if (person == null)
            {
                return Content("Person is not matched");
            }
            return View(person);


        }

        [Route("person-with-products")]
        public IActionResult PersonWithProducts()
        {
            Person p1 = new Person()
            {
                Name = "Altaf",
                DateOfBirth = Convert.ToDateTime("2004-09-23"),
                MyGender = Gender.male
            };

            Product product=new Product() { Name="Paper",ProductId=1};
            //ProductAndPersonWrapperModel viewModel = new ProductAndPersonWrapperModel()
            //{
            //    Person = p1,
            //    Product = product
            //};

            ProductAndPersonWrapperModel viewModel=new ProductAndPersonWrapperModel();
            viewModel.Product = product;
            viewModel.Person = p1;

           
            return View(viewModel);
        }

        [Route("homeproducts/all")]
        public IActionResult All()
        {
            return View();
        }
    }

}
