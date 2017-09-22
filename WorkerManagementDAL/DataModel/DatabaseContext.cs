namespace WorkerManagementDAL.DataModel
{
    using System.Data.Entity;



    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseConnection")
        {

        }



        public DbSet<Worker> Workers { get; set; }
    }
}