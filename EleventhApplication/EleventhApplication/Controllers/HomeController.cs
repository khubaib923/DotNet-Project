using EleventhApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EleventhApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public readonly WeatherApiOption weather;

        public HomeController(IConfiguration configuration,IOptions<WeatherApiOption> options)
        {
            _configuration = configuration;
            weather = options.Value;
        }

        [Route("/home")]
        public IActionResult Index()
        {
            //First read the appsetting,appsetting.Enivornment,usersecret,commandline Arguments
            IConfigurationSection section = _configuration.GetSection("key");
            ViewBag.section1 = section["MyClientKey"];
            ViewBag.section2 = section["MyApiKey"];
            ViewBag.key = _configuration["MyKey"];
            ViewBag.key1 = _configuration.GetValue<string>("key", "key is not present");
            ViewBag.key2 = _configuration["key:MyClientKey"];
            //loads configuration value into a new options object
            WeatherApiOption option=_configuration.GetSection("key").Get<WeatherApiOption>()!;
            ViewBag.MyCLientKey = option.MyClientKey;
            ViewBag.MyApiKey = option.MyApiKey;
            WeatherApiOption weatherApiOption = new WeatherApiOption();
            //Bind:Loads configuration values into existing options object.
            _configuration.GetSection("key").Bind(weatherApiOption);
            ViewBag.bindClientKey = weatherApiOption.MyClientKey;
            ViewBag.bindApiKey = weatherApiOption.MyApiKey;
            ViewBag.serviesClientKey = weather.MyClientKey;
            ViewBag.servicesApiKey = weather.MyApiKey;

            return View();
        }
    }
}
