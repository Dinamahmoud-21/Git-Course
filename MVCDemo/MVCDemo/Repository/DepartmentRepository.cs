using MVCDemo.Models;

namespace MVCDemo.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {
        ITIEntity context;

        public Guid ID { get ; set; }

        public DepartmentRepository(ITIEntity _context)//ask service provider from ITIEntity
        {
            ID = Guid.NewGuid();//unique string
            context = _context;// new ITIEntity();
        }

        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(e => e.Id == id);
        }
        //Unit of Work
        public void Insert(Department item)
        {
            context.Department.Add(item);
            context.SaveChanges();
        }

        public void Update(int id, Department item)
        {
            //get old reference
            Department oldDept = GetById(id);
            //chaneg value(autoMapper)
            oldDept.Name = item.Name;
            oldDept.ManagerName = item.ManagerName;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Department oldDept = GetById(id);
            context.Department.Remove(oldDept);
            context.SaveChanges();
        }
    }
}
