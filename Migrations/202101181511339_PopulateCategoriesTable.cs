namespace ProjektSemestralnyCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Categories (Name) 
                VALUES 
                    ('Monitors'),
                    ('Printers'),
                    ('Network Devices'),
                    ('Mouse'),
                    ('Projectors'), 
                    ('Keyboards'),
                    ('Headsets'),
                    ('Speakers'),
                    ('Microphones'),
                    ('Mousepads')
            ");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id BETWEEN 1 AND 10");
        }
    }
}
