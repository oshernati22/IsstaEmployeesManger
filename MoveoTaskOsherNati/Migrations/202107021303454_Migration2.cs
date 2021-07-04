namespace MoveoTaskOsherNati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "gender", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "StudentGender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "StudentGender", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "gender");
        }
    }
}
