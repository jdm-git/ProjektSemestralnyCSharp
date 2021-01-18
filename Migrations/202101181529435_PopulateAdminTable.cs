namespace ProjektSemestralnyCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAdminTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Admins (Login, Password)
                VALUES
                    ('admin','admin'),
                    ('root','root')"
            );
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id BETWEEN 1 AND 2");
        }
    }
}
