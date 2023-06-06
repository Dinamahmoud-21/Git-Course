using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public class EmployeeMemoryRepository: IEmployeeRespoitory
    {
        List<Employee> Emps;
        public EmployeeMemoryRepository()
        {
            Emps = new List<Employee>();
            Emps.Add(new Employee() { Id = 1, Name = "ahmed" });
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return Emps;
        }

        public List<Employee> GetByDeptID(int deptid)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            return Emps.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(Employee item)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
