using Autofac;
using ContractService;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace NinethApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILifetimeScope _lifeTimeScope;
       
        

       
        public HomeController(ICitiesService citiesservice1, ICitiesService citiesservice2, ICitiesService citiesservice3,IServiceScopeFactory serviceScopeFactory,ILifetimeScope lifetimeScope)
        {
            _citiesService1 = citiesservice1;
            _citiesService2 = citiesservice2;
            _citiesService3 = citiesservice3;
            _serviceScopeFactory = serviceScopeFactory;
            _lifeTimeScope = lifetimeScope;
            

        }
        [Route("/")]
        public IActionResult Index(/*[FromServices] ICitiesService _citiesService*/)
        {

           
            ViewBag.Guid_1 = _citiesService1.ServiceInstance;
            ViewBag.Guid_2 = _citiesService2.ServiceInstance;
            ViewBag.Guid_3 = _citiesService3.ServiceInstance;
            //child scope
            using (IServiceScope scope=_serviceScopeFactory.CreateScope())
            {
                ICitiesService services=scope.ServiceProvider.GetService<ICitiesService>()!;
                ViewBag.ServiceInstance = services.ServiceInstance;

            }
            //ILifeTime child scope
            using(ILifetimeScope scopes = _lifeTimeScope.BeginLifetimeScope())
            {
                ICitiesService citiesService=scopes.Resolve<ICitiesService>();

                ViewBag.lifescope = citiesService.ServiceInstance;
            }



                List<string> cities = _citiesService1.GetCities();
            return View(cities);
        }
    }
}
