using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;
using MVCDemo.Repository;
using MVCDemo.ViewModel;

namespace MVCDemo.Controllers
{
    //IOc - DIP
    public class EmployeeController : Controller//high level class
    {
        //DIP
        IEmployeeRespoitory EmployeeRepository;//=new EmployeeRepository();//null
        IDepartmentRepository DepartmentRepository;
        
        public EmployeeController
            (IEmployeeRespoitory _EmpRep,IDepartmentRepository _DeptRep)//ask service provider
        {
            EmployeeRepository = _EmpRep;//tigh couple dont create 
            DepartmentRepository = _DeptRep;// new DepartmentRepository();//deont ask
        }

        public IActionResult ShowDepartments()
        {
            return View(DepartmentRepository.GetAll());
        }
        //Employee/getempbydeptis?DeptId=1
        public IActionResult GetEmpByDeptId(int DeptID)
        {
            List<Employee> Emps = EmployeeRepository.GetByDeptID(DeptID);
            return Json(Emps);//list==>[]
        }

        //Employee/testPartial/1
        public IActionResult testPartial(int id)
        {
            Employee empModel = EmployeeRepository.GetById(id);
            return PartialView("_EmpCardPartial",empModel);//return view without layout
            //return View();//viewStart Layout
        }     


        //View Support client side Validation "Calling by Ajax"
        public IActionResult CheckAddress(string Address ,int Salary)
        {
            if((Address == "Assiut" || Address== "Sohag" ) && (Salary %5==0))
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }


        //name=ahmed
        public IActionResult New()
        {
            ViewData["Depts"] = DepartmentRepository.GetAll();//list<department>
            return View();
        }
        [HttpPost]
        public IActionResult New(Employee newEmp)
        {
            if (ModelState.IsValid==true)//Server side validation
            {
                try
                {
                    EmployeeRepository.Insert(newEmp);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    //send info ==>view
                    //ModelState.AddModelError("Exception", ex.InnerException.Message);
                    ModelState.AddModelError("DeptId", "Select Specific Department ");

                }
            }
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View(newEmp);//Model Employee ,view ==>NEw ,modelstate
        }

        public IActionResult Index()
        {

            return View(EmployeeRepository.GetAll());
        }
        //anchor 
        public IActionResult Edit(int id) {
            Employee empModel = EmployeeRepository.GetById(id);
            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View(empModel);//view =Edit ,model= Employee
        }

        [HttpPost]
        public IActionResult Edit(int id,Employee empForm)
        {
           // if (empForm.Name != null)//your own condition
            if(ModelState.IsValid)
            {
                EmployeeRepository.Update(id, empForm);
                return RedirectToAction("Index");
            }

            ViewData["Depts"] = DepartmentRepository.GetAll();
            return View(empForm);//view =Edit ,model= Employee
        }


        //Employee/DEtails/1?name=ahmed

        public IActionResult Details(int id,string name)
        {
            
            List<string> braches=new List<string>();
            braches.Add("Alex");
            braches.Add("Assiut");
            braches.Add("Cairo");
            braches.Add("MAnsoura");
            braches.Add("Sohag");
            //use ViewData
            ViewData["brch"]= braches;
            ViewData["msg"] = "Hello";
            ViewData["slr"] = 1000;
            ViewData["clr"] = "Red";
            ViewBag.clr = "Blue";

            ViewBag.Track = "SD";

            Employee empModel = EmployeeRepository.GetById(id);
            return View(empModel);//View name="DEtails" , Model=Employee
        }

        public IActionResult DetailsVM(int id)
        {
            List<string> braches = new List<string>();
            braches.Add("Alex");
            braches.Add("Assiut");
            braches.Add("Cairo");
            braches.Add("MAnsoura");
            braches.Add("Sohag");
            
            Employee empModel = EmployeeRepository.GetById(id);
            //create viewModel Object
            EmployeeWithBrachsMsgColorViewModel empVM = new EmployeeWithBrachsMsgColorViewModel();

            //mapping model ==>viewModel
            empVM.EmployeeName = empModel.Name;
            empVM.Branches = braches;
            empVM.Color = "Blue";
            empVM.Track = "SD";
            empVM.Msg = "Hello";
            empVM.Salary = 1000;

            //return view ==>viewModel as model
            return View(empVM);
        }
    }
}
