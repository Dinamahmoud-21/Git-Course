using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class BindingController : Controller
    {
        //Model Binding :get info from client"HTML " ==> server "Action Parameter"

        //Binding/testPremitive?age=30&name=Ahmed&id=33
        //Binding/testPremitive/33?age=30&name=Ahmed&color=red&color=blue
        //Binding/testPremitive/33?color[1]=red&color[0]=blue
        public IActionResult testPremitive(int age ,string name,int id ,string[] color)
        {
            return Content($"name={name} \t age={age}");
        }

        //binding Collection "List,Dictionary"
        //Binding/testDic?name=ahmed&phone[ahmed]=123&phone[christen]=456&depts[0].Name=sd
        public IActionResult testDic(string name,Dictionary<string,string> Phone,List<Department> depts)
        {
            return Content("Dic");
        }

        //bind Custom type "Class" Model
        //Binding/testObj?id=1&name=sd&ManagerName=ahmed&Emps[0].Name=Mohamed
        public IActionResult testObj(string name,Department dept)
        {
            
            return Content("obj");
        }

    }
}
