using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using System.Diagnostics;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        ////Action
        //1- must public 
        //2- can't be static 
        //3- can't be overload 


        //Domain/Home/myMethod
        public string myMethod()
        {
            return "Hello From My Method";
        }
        public ContentResult myMethod2()
        {
            //DEclare 
            ContentResult result = new ContentResult();
            //set data
            result.Content = "Hello From My Method2";
            //return
            return result;
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //declare
            ViewResult result=new ViewResult();
            //set  view name
            result.ViewName = "MyView";
            //1- Views/Home/MyView
            //2- Views/Shared/MyView
            //3- Exception
            //return
            return result;
        }
        //Action content | View
        //Home/mix/1
        //Home/mix?id=1 & name=ahmed
        public IActionResult mix(int id)
        {
            
            if (id % 2 == 0)
            {
                return Content("My MEssage");
            }
            else
            {
                return View("MyView");
            }
        }




        //action reture        class
        //1- content "String"  ContentResult
        //2- html "View"       ViewResult
        //3- Json              JsonResult
        //4- File "pdf"        FileResult
        //5- javascript        JavascriptResult
        //6- NotFound          NotFoundResult
        //7- ....









        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}