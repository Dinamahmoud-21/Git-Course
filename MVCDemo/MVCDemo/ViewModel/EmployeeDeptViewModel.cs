using MVCDemo.Models;

namespace MVCDemo.ViewModel
{
    public class EmployeeDeptViewModel
    {
        public string   EmpNAme { get; set; }
        public int id { get; set; }
        public int Salary { get; set; }
        //public Employee Emp { get; set; }//Reject
        public List<Department> Dept { get; set; }
        //public string   EmpNAme { get; set; }
        //public string   DeprtNAme { get; set; }

    }
}
