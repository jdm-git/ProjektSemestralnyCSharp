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

        public ProjectContext()
            : base("name=ProjectContext")
        {
        }

    }


}