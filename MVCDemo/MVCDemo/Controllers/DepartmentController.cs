using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;
using MVCDemo.Repository;

namespace MVCDemo.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        //DIP
        IEmployeeRespoitory EmployeeRepository;//=new EmployeeRepository();//null

        IDepartmentRepository DepartmentRepository;
        //DI
        public DepartmentController(IDepartmentRepository DeptRepo, IEmployeeRespoitory EmpREpo)//ask inject not create
        {
            EmployeeRepository = EmpREpo;//tigh couple dont create 

            DepartmentRepository =  DeptRepo;
        }
        // ITIEntity context = new ITIEntity();
        [Authorize(Roles ="Admin")]//cookie & role Admin
        public IActionResult Index()
        {
            List<Department> deptsModel =
                DepartmentRepository.GetAll();
            //1 return View("Index",deptsModel);//View name="Index" ,Model  = List<Department>
            //2 return View("Index");           //View name="Index"  ,Model   =Null
            //3 return View();                  //View name="Index"  ,Model   =Null
            return View(deptsModel);            //View name="Index"  ,Model  =List<department>
        }
        //anchor tage
        
        public IActionResult New()
        {
            return View("New");//View name=New ,Model =null
        }
        //submit button
        
        [HttpPost]//if(request.Method=="Post")
        public IActionResult SaveNew(Department newDept) //handdle any request method
        {
            if (newDept.Name != null && newDept.ManagerName!=null) 
            {

                DepartmentRepository.Insert(newDept);
                // return View("Index",context.Department.ToList());
                return RedirectToAction("Index");
            }
                return View("New", newDept);//view name=
        }


        //-------------Actions cant be overload-------------------
        //Department/Method1 ==>Get
        [HttpGet]
        [AllowAnonymous]//dont search for cookie auth
        public IActionResult MEthod1()
        {
            return Content("Method1 _ Get");
        }


        [HttpPost] //Department/method1 ==>Post
        public IActionResult MEthod1(int id)
        {
            return Content("Method1 _ post");
        }

    }
}
