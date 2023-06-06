using Microsoft.EntityFrameworkCore;

namespace MVCDemo.Models
{
    public class ITIEntity:DbContext
    {
        //connection string "server name, databse ,autho"
        public ITIEntity() : base()
        { }//scaffolding 

        public ITIEntity(DbContextOptions options):base(options)
            //ask serveice provider ==>option appsetting.json
        {
            //sjfsafjasl
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITISohag;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
