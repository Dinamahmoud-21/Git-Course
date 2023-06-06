using Microsoft.AspNetCore.Mvc;

namespace MVCDemo.Controllers
{
    public class RoutingController : Controller
    {
        //r1/index
        [Route("r1/{name?}/{age?}")]//Web api  Routing Attrinute
        public IActionResult Index()//string name,int age)
        {
            return Content("Method1");
        }
        //r1/index2
        public IActionResult Index2()
        {
            return Content("Method2");
        }
    }
}
