namespace MoveoTaskOsherNati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "StudentGender", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "type", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "gender");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "gender", c => c.String());
            AlterColumn("dbo.Employees", "type", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "StudentGender");
        }
    }
}
