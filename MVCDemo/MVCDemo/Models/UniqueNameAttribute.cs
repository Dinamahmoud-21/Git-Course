using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Models
{
    /*
        check attrbute if static value
        check from databse
     */
    //Server side only
    public class UniqueNameAttribute:ValidationAttribute
    {
        //public int dividBy { get; set; }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)//value= ahmed ,deprtment=1
        {
            //name unique per department
            string name = value.ToString();
           
            Employee empFromRequest= (Employee) validationContext.ObjectInstance;

            //if(name% dividBy)
            ITIEntity context = new ITIEntity();
            Employee empFromDb = 
                context.Employee.FirstOrDefault(e => e.Name == name && e.DeptId== empFromRequest.DeptId);
            if(empFromDb == null) {
                return ValidationResult.Success;//valid value
            }
            //logic
            return new ValidationResult("Name Already Found in this department");
        }
    }
}
