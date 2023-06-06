using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    public class Department
    {
        //[Key]
        public int Id { get; set; }//primary key +idenity
        public string Name { get; set; }
        public string ManagerName { get; set; }
        
        public List<Employee>? Emps { get; set; }

    }
}
