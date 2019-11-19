namespace SimpleSheduler.BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameNametoAbbreviation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Classrooms", "Abbreviation", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Groups", "Abbreviation", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Subjects", "Abbreviation", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Subjects", "Lect_TypeUnionGroupId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Lect_TypeUnionGroupId1", c => c.Int());
            AddColumn("dbo.StudyDays", "AbbreviationDayOfWeek", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Subjects", "Lect_TypeUnionGroupId1");
            AddForeignKey("dbo.Subjects", "Lect_TypeUnionGroupId1", "dbo.TypeUnionGroups", "TypeUnionGroupId");
            DropColumn("dbo.Classrooms", "Name");
            DropColumn("dbo.Groups", "Name");
            DropColumn("dbo.Subjects", "Name");
            DropColumn("dbo.StudyDays", "NameDayOfWeek");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudyDays", "NameDayOfWeek", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Subjects", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Groups", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Classrooms", "Name", c => c.String(nullable: false, maxLength: 20));
            DropForeignKey("dbo.Subjects", "Lect_TypeUnionGroupId1", "dbo.TypeUnionGroups");
            DropIndex("dbo.Subjects", new[] { "Lect_TypeUnionGroupId1" });
            DropColumn("dbo.StudyDays", "AbbreviationDayOfWeek");
            DropColumn("dbo.Subjects", "Lect_TypeUnionGroupId1");
            DropColumn("dbo.Subjects", "Lect_TypeUnionGroupId");
            DropColumn("dbo.Subjects", "Abbreviation");
            DropColumn("dbo.Groups", "Abbreviation");
            DropColumn("dbo.Classrooms", "Abbreviation");
        }
    }
}
