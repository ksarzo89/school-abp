namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        CI = c.Long(nullable: false),
                        Age = c.Int(nullable: false),
                        AssignedGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppGroup", t => t.AssignedGroupId)
                .Index(t => t.AssignedGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppStudent", "AssignedGroupId", "dbo.AppGroup");
            DropIndex("dbo.AppStudent", new[] { "AssignedGroupId" });
            DropTable("dbo.AppStudent");
            DropTable("dbo.AppGroup");
        }
    }
}
