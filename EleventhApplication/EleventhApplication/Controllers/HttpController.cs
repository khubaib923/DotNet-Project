using EleventhApplication.IServices;
using EleventhApplication.Models;
using EleventhApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EleventhApplication.Controllers
{
    public class HttpController : Controller
    {
        private readonly IMyService _myService;
        private readonly IConfiguration _configuration;

        public HttpController(IMyService myService, IConfiguration configuration)
        {
            _myService = myService;
            _configuration = configuration;
        }
        [Route("/index")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string,object>result= await _myService.Method(_configuration["symbol"]??"MSFT");
            //Stock stock= new Stock() { StockSymbol=result.Values};
            return View();
        }
    }
}
