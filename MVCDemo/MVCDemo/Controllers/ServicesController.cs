using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Repository;

namespace MVCDemo.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IDepartmentRepository deptRepo;
        private readonly IConfiguration configuration;

        public ServicesController
            (IDepartmentRepository _deptRepo,IConfiguration Configuration)
        {
            deptRepo = _deptRepo;
            configuration = Configuration;
        }
        //inject action
        //Service/testservice
        public IActionResult testService()
            //(int id,[FromServices] IDepartmentRepository _deptRepo)//Model binding
        {
            string appname = configuration["app"];
                ViewData["ID"] = deptRepo.ID;
            return View();
        }
    }
}
