using MVCDemo.Models;

namespace MVCDemo.Repository
{
    //contract
    public interface IDepartmentRepository
    {
        Guid ID { get; set; }//string unique

        List<Department> GetAll();
        
        Department GetById(int id);
        
        void Insert(Department item);
        
        void Update(int id, Department item);
        
        void Delete(int id);
    }
}
