namespace ProjektSemestralnyCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingProductProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "Isbn");
            DropColumn("dbo.Products", "Title");
            DropColumn("dbo.Products", "Author");
            DropColumn("dbo.Products", "Pages");
            DropColumn("dbo.Products", "Publisher");
            DropColumn("dbo.Products", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Publisher", c => c.String());
            AddColumn("dbo.Products", "Pages", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Author", c => c.String());
            AddColumn("dbo.Products", "Title", c => c.String());
            AddColumn("dbo.Products", "Isbn", c => c.String());
            DropColumn("dbo.Products", "Price");
        }
    }
}
