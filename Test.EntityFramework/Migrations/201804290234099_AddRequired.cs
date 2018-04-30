namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppGroup", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AppStudent", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppStudent", "FullName", c => c.String());
            AlterColumn("dbo.AppGroup", "Name", c => c.String());
        }
    }
}
