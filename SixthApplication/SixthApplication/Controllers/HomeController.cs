﻿using Microsoft.AspNetCore.Mvc;

namespace SixthApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {

            return View();
        }
        [Route("contact")]
        public IActionResult Contact()
        {

            return View();
        }
    }
}
