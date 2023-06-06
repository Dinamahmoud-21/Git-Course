using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public interface IEmployeeRespoitory
    {
        List<Employee> GetAll();

        Employee GetById(int id);

        List<Employee> GetByDeptID(int deptid);
        
        //Unit of Work
        void Insert(Employee item);

        void Update(int id, Employee item);

        void Delete(int id);
      
    }
}