using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Employee Name")]
        // [DataType(DataType.EmailAddress)]
        //[Required]
        [MinLength(3,ErrorMessage ="name must be more than 2 char")]
        [MaxLength(25)]
        [UniqueName]//(ErrorMessage ="name already Found")]
        public string Name { get; set; }

        [Range(8000,20000,ErrorMessage ="Salary must be between 8000 to 20000")]
        public int Salary { get; set; }

        //Employee/CheckAddress?Address= &Salary=
        [Remote("CheckAddress","Employee",AdditionalFields = "Salary", ErrorMessage ="Address must be Assiut , Sohag")]
        public string? Address { get; set; }

        [RegularExpression(@"\w+\.(jpg|png|gif)",ErrorMessage ="Image must be jpg ,png ,gif")]//asda.jpg ,asd.png ,asd.jif
        public string Image { get; set; }
        
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DeptId { get; set; }

        public Department? Department { get; set; }//model state 
    }
    //lazy loading off
}
