using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MVCDemo.Models;

namespace MVCDemo.Controllers
{
    public class StudentController : Controller
    {
        //Student/ShowAll
        public IActionResult ShowAll()
        {
            
            //get data From Model
            List<Student> students= StudentBL.GetAll();//Data
            //send view
            return View("AllStudent", students);//View = AllStudent ,model =students
        }
        //Student/Details/1
        //Student/Details?id=1
        public IActionResult Details(int id)
        {
            //get info model BL
            List<Student> students = StudentBL.GetAll();//Data
            Student StudentModel   = students.FirstOrDefault(x => x.Id == id);
             return View("ShowStudent", StudentModel);//Model ==>student
        }




        //public int add(int x,int y)
        //{

        //}
    }
    //class parent<T>
    //{
    //    public T Model { get; set; }
    //}

    //class child : parent<dynamic>
    //{

    //}
}
