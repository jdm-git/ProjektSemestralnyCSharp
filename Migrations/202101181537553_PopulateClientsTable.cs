namespace ProjektSemestralnyCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateClientsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Clients (Login, Password, FirstName, LastName, Adress, State, Phone, ZipCode, Email)
VALUES
('jsmith', 'Smithysmith', 'John', 'Smith', 'Swimmers Street 11', 'Arizona', '123456789', '11-201', 'johnsmith@gmail.com'),
('janek88', 'nowak123', 'Jan', 'Nowas', 'Aleje 29 Listopada 54', 'Malopolska', '987654321', '33-111', 'nowak88@gmail.com'),
('Ol@Smyk', 'Qwertyuiop2021', 'Aleksandra', 'Smyk', 'Floriañska 5', 'Malopolska', '123466789', '30-101', 'aleksandras@gmail.com')
");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id BETWEEN 1 AND 3");
        }
    }
}
