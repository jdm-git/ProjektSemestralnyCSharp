namespace ProjektSemestralnyCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProductsTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Products (CategoryId, Description, Price, Name)
VALUES
(1, '27 inch monitor 1080p', 999,'Samsung Odyssey F27G35TFWUX'),
(4, 'Zowie Gaming Mouse, 3200DPI, 5 buttons!', 329.99,'Zowie EC2'),
(6, 'Razers Gaming keyboard with keys backlight', 649.99, 'Razer BlackWidow Elite Green Switch'),
(7, 'Dedicated for gaming OMEN headset', 699.99, 'HP Omen Mindframe Headset')
");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Products WHERE Id BETWEEN 1 AND 4");
        }
    }
}
