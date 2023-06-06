using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public class EmployeeRepository:IEmployeeRespoitory
    {
        //CRUD (Create -REad - Update - Delete)
        ITIEntity context;
        public EmployeeRepository(ITIEntity _context)
        {
            context = _context;// new ITIEntity();
        }

        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public Employee GetById(int id)
        {
            return context.Employee.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetByDeptID(int deptid)
        {
            return context.Employee.Where(e => e.DeptId == deptid).ToList();
        }
        //Unit of Work
        public void Insert(Employee item)
        {
            context.Employee.Add(item);
            context.SaveChanges();
        }

        public void Update(int id,Employee item)
        {
            //get old reference
            Employee oldEmp = GetById(id);
            //chaneg value(autoMapper)
            oldEmp.Name = item.Name;
            oldEmp.Salary = item.Salary;
            oldEmp.Image = item.Image;
            oldEmp.Address = item.Address;
            oldEmp.DeptId = item.DeptId;
            //save change
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee oldEmp = GetById(id);
            context.Employee.Remove(oldEmp);
            context.SaveChanges();
        }
    }
}
