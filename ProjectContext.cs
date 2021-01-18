namespace ProjektSemestralnyCSharp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProjectContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

    }


}