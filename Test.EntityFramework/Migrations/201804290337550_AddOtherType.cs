namespace Test.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtherType : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.AppStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        CI = c.Long(nullable: false),
                        Age = c.Int(nullable: false),
                        AssignedGroupId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Student_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.AppStudent", "IsDeleted");
            DropColumn("dbo.AppStudent", "DeleterUserId");
            DropColumn("dbo.AppStudent", "DeletionTime");
            DropColumn("dbo.AppStudent", "LastModificationTime");
            DropColumn("dbo.AppStudent", "LastModifierUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppStudent", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.AppStudent", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.AppStudent", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.AppStudent", "DeleterUserId", c => c.Long());
            AddColumn("dbo.AppStudent", "IsDeleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.AppStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        CI = c.Long(nullable: false),
                        Age = c.Int(nullable: false),
                        AssignedGroupId = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Student_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
