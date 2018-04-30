namespace Test.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddListStudents : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.AppGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Group_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.AppStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        CI = c.Long(nullable: false),
                        Age = c.Int(nullable: false),
                        AssignedGroupId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
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
            
            AddColumn("dbo.AppGroup", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppGroup", "DeleterUserId", c => c.Long());
            AddColumn("dbo.AppGroup", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.AppGroup", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.AppGroup", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.AppGroup", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppGroup", "CreatorUserId", c => c.Long());
            AddColumn("dbo.AppStudent", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppStudent", "DeleterUserId", c => c.Long());
            AddColumn("dbo.AppStudent", "DeletionTime", c => c.DateTime());
            AddColumn("dbo.AppStudent", "LastModificationTime", c => c.DateTime());
            AddColumn("dbo.AppStudent", "LastModifierUserId", c => c.Long());
            AddColumn("dbo.AppStudent", "CreationTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppStudent", "CreatorUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppStudent", "CreatorUserId");
            DropColumn("dbo.AppStudent", "CreationTime");
            DropColumn("dbo.AppStudent", "LastModifierUserId");
            DropColumn("dbo.AppStudent", "LastModificationTime");
            DropColumn("dbo.AppStudent", "DeletionTime");
            DropColumn("dbo.AppStudent", "DeleterUserId");
            DropColumn("dbo.AppStudent", "IsDeleted");
            DropColumn("dbo.AppGroup", "CreatorUserId");
            DropColumn("dbo.AppGroup", "CreationTime");
            DropColumn("dbo.AppGroup", "LastModifierUserId");
            DropColumn("dbo.AppGroup", "LastModificationTime");
            DropColumn("dbo.AppGroup", "DeletionTime");
            DropColumn("dbo.AppGroup", "DeleterUserId");
            DropColumn("dbo.AppGroup", "IsDeleted");
            AlterTableAnnotations(
                "dbo.AppStudent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        CI = c.Long(nullable: false),
                        Age = c.Int(nullable: false),
                        AssignedGroupId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
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
            
            AlterTableAnnotations(
                "dbo.AppGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Group_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
