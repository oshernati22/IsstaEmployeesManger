namespace MoveoTaskOsherNati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration33 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        phoneNumber = c.Int(nullable: false),
                        gender = c.String(),
                        startDate = c.String(nullable: false),
                        type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
